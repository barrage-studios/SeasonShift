using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletCollisions3 : MonoBehaviour {

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

            UICounterStatic.UIScript.updateScore(pointsPerHit);

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
            checkBoss3Death.boss3death = checkBoss3Death.boss3death + 1;
        }


        Destroy(enemy.gameObject);

    }
}
