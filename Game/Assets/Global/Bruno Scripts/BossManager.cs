using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour {

    // Movement Data
    public float maxX = 6.1f;
    public float minX = -6.1f;
    public float maxY = 4.2f;
    public float minY = -4.2f;
    public float moveSpeed = 1f;

    private float tChange = 0; // force new direction in the first Update
    private float randomX;
    private float randomY;

    // Enemy Bullet Collision Data
    public int playerBulletLayer;
    public int life;
    public GameObject levelManager;
    public int pointsPerHit;

    void Update()
    {
        // change to random direction at random intervals
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-2.0f, 2.0f); // with float parameters, a random float
            randomY = Random.Range(-2.0f, 2.0f); //  between -2.0 and 2.0 is returned
                                               // set a random interval between 0.5 and 1.5
            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }

        transform.Translate( new Vector3(randomX, randomY, 0) * moveSpeed * Time.deltaTime);
        // if object reached any border, revert the appropriate direction
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            randomX = -randomX;
        }
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            randomY = -randomY;
        }
        // make sure the position is inside the borders

        Vector3 boss = transform.position;
        float bossx = boss.x;
        float bossy = boss.y;

        Mathf.Clamp( bossx, minX, maxX);
        Mathf.Clamp( bossy, minY, maxY);
    }

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
        GameData._instance.setPlaying(false);
        yield return new WaitForSeconds(.05f);
        if (!SceneEngine.PeekStack().Equals(SceneEngine.Scenes.WINTER))
        {
            GameData._instance.playerProfile.progressLevels();
        }
        else
        {
            Debug.LogWarning("No more levels to beat!");
        }
        SceneEngine.PopScene();
    }
}
