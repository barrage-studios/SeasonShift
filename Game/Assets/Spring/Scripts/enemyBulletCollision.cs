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


        Debug.Log("OnCollisionEnter2D");

        if (col.gameObject.layer == playerBulletLayer)
        {

            life = life - 1;

            Destroy(col.gameObject);
            
            initializeScoreCounter.lev1ScoreCounter = initializeScoreCounter.lev1ScoreCounter + pointsPerHit;

            if (life <= 0)
            {

                StartCoroutine("death");

            }


        }

        


    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(.05f);

        if (this.gameObject.layer == 12)
        {
            checkBossDeath.boss1death = checkBossDeath.boss1death + 1;
        }


        Destroy(enemy.gameObject);

    }
}
