using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    public float spawnSpeed;
    public float invTime1;
    public float invTime2;  // this has to be greater than the first invTime
    public float firstSpeed = 5;
    public float secondSpeed = 3;
    public int playerLayer;
    public int enemyBulletLayer;
    public int playerBulletLayer;
    public float shootingInterval;
    public float blinkInterval;

    public GameObject playerBulletPrefab;
    public GameObject playerPrefab;
    public GameObject initialspawnPos; // the location the player will spawn after death(if it still has enough lives left)
    public static bool isKillable;

    private float amTime = 0;
    private float speed;
    private bool check = true;   // This check and the one below are used in the player shooting coroutine, to make sure that it doesn't continue on forever
    private bool check2 = false;
    private bool playerMovementActive = true;


    IEnumerator shooting()
    {

        yield return new WaitWhile(() => check);

        while (check2)
        {
            Quaternion angle = Quaternion.Euler(0, 0, 90);

            Instantiate(playerBulletPrefab, (playerPrefab.transform.position), angle);

            yield return new WaitForSeconds(shootingInterval);
        }
    }

    IEnumerator playerBlink()    // the only thing this does is when the player spawns is that it turns off and on the sprite renderer
    {

        float strTime = amTime;  // finds what time it is when the player spawns


        while (amTime < strTime + invTime2) // this will run until the amount of time that has passed is greater than the start time and the second invulnerable time
        {

            playerPrefab.GetComponent<SpriteRenderer>().enabled = !(playerPrefab.GetComponent<SpriteRenderer>().enabled); // this is what is finding the sprite renderer and turning it the opposite of whatever it is currently

            yield return new WaitForSeconds(blinkInterval);

        }


        playerPrefab.GetComponent<SpriteRenderer>().enabled = true; // the coroutine ends with the sprite renderer on
        yield return new WaitForSeconds(0);
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(0f);

        if (isKillable)
        {
            playerLives.deathDetect = playerLives.deathDetect + 1;

            Destroy(this.gameObject);
        }
    }



    IEnumerator playerMove()
    {

        float strTime = amTime;


        yield return new WaitForSeconds(0);

        isKillable = false;

        while (amTime < invTime1 + strTime)
        {
            playerMovementActive = false;   // turns off the player movement section of the code
            transform.position += transform.up * Time.deltaTime * spawnSpeed; // should move the player into the screen while the user can't move around
            yield return new WaitForEndOfFrame();
        }

        playerMovementActive = true; // when the above loop ends the player gets his movement back but should still have invulnerability for a few seconds

        while (amTime < invTime2 + strTime)
        {
            yield return new WaitForEndOfFrame();
        }

        isKillable = true;
        Debug.Log(isKillable);
    }



    public void Start()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, playerBulletLayer);
        StartCoroutine("playerMove"); // this and the next coroutine are utilized when the player spawns
        StartCoroutine("playerBlink");
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.layer == enemyBulletLayer)
        {
            Debug.Log("Y");

            Destroy(col.gameObject);

            StartCoroutine("death");

        }

    }

    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        // The next two bool operators are simply limiting the player shooting part of the script

        if (Input.GetKeyDown(KeyCode.Z))
        {
            check = false;
            check2 = true;
            StartCoroutine("shooting");
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            check = true;
            check2 = false;
        }


        if (playerMovementActive)
        {
            if (Input.GetButton("Fire3")) // detecting if the left shift button is being pressed down and will change the player's speed if it is
            {
                speed = secondSpeed;
                Vector3 tempVect = new Vector3(h, v, 0);
                tempVect = tempVect.normalized * speed * Time.fixedDeltaTime;
                playerPrefab.transform.position += tempVect;
            }
            else // this is the general speed of the player
            {
                speed = firstSpeed;
                Vector3 tempVect = new Vector3(h, v, 0);
                tempVect = tempVect.normalized * speed * Time.fixedDeltaTime;
                playerPrefab.transform.position += tempVect;
            }
        }

        amTime = amTime + Time.deltaTime; // tracks the time that has been passing
    }
}
