using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetedMovement : MonoBehaviour
{
    public float moveSpeed;

    private float x;
    private float y;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        x = player.GetComponent<Transform>().position.x;
        y = player.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float thisx = transform.position.x;
        float thisy = transform.position.y;
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(x,y), step);
    }
}
