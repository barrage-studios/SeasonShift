using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollisions : MonoBehaviour {

    public int bulletLayer;

    public GameObject thingCollider;

    void OnCollisionEnter2D(Collision2D col)
    {


        Debug.Log("OnCollisionEnter2D");

        if (col.gameObject.layer == bulletLayer) {

            Destroy(col.gameObject);

            StartCoroutine("death");

        }

    }

    IEnumerator death() {
        yield return new WaitForSeconds(0f);

        


        if (playerInvincibility.isKillable)
        {
            playerLives.deathDetect = playerLives.deathDetect + 1;
            Destroy(thingCollider.gameObject);
        }

        

    }


}
