using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public static bool bombActive = false;

    private CircleCollider2D bombHitbox;
    private SpriteRenderer bombVisual;
    private float maxSize = 50;

    void Start()
    {
        bombHitbox = GetComponent<CircleCollider2D>();
        bombVisual = GetComponent<SpriteRenderer>();
        bombVisual.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && playerLives.bombs > 0 && bombActive == false)
        {
            bombActive = true;
            bombVisual.enabled = true;
            playerLives.bombs += -1;
            StartCoroutine("bomb");
        }
    }

    IEnumerator bomb()
    {
        while(bombHitbox.radius < maxSize)
        {
            bombHitbox.radius++;

            yield return new WaitForSeconds(0.1f);
        }
        bombActive = false;
        bombHitbox.radius = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(bombActive == true && collision.gameObject.layer == 11)
        {
            Destroy(collision.gameObject);
        }
    }
}
