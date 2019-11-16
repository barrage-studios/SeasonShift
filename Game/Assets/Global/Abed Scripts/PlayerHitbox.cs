using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true; // Makes player's hitbox invisible
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet" && playerManager.isKillable == true) // If hitbox collides with bullet
        {
            Destroy(collision.gameObject);
            playerManager playerScript = GetComponentInParent<playerManager>();
            playerScript.StartCoroutine("death");
            UICounterStatic.UIScript.updateLife(-1);
            UICounterStatic.UIScript.resetGraze();
        }
    }
}
