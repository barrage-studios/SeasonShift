using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBulletCollision : MonoBehaviour {

    public int playerBulletLayer;

    public int life;

    public GameObject enemy;

    public int pointsPerHit;

    


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.layer == playerBulletLayer)
        {

            life = life - 1;

            Destroy(col.gameObject);
            
            playerLives.points = playerLives.points + pointsPerHit;

            if (life <= 0)
            {

                StartCoroutine("death");

            }


        }

        


    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(.05f);



        Destroy(enemy.gameObject);

    }
}
