using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInvincibility : MonoBehaviour {

    
    public int velocity;
    public float invTime1;
    public float invTime2;
    public int enemyBulletLayer;
    public int playerLayer;
    public float blinkInterval;
    
    public GameObject player;


    public static bool isKillable;
    private float amTime = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine("playerMove");
        StartCoroutine("playerBlink");
    }

    IEnumerator playerBlink() {
        yield return new WaitForSeconds(0);
        float strTime = amTime;


        while (amTime < strTime+invTime2) {

            player.GetComponent<SpriteRenderer>().enabled = !(player.GetComponent<SpriteRenderer>().enabled);

            yield return new WaitForSeconds(blinkInterval);

        }


        player.GetComponent<SpriteRenderer>().enabled = true;

    }



    IEnumerator playerMove() {

        float strTime = amTime;


        yield return new WaitForSeconds(0);

        isKillable = false;

        

        while (amTime < invTime1+strTime) {
            player.GetComponent<playerMovement>().enabled = false;
            transform.position += transform.up * Time.deltaTime * velocity;
            yield return new WaitForEndOfFrame();
        }

        player.GetComponent<playerMovement>().enabled = true;

        while (amTime < invTime2+strTime) {
            yield return new WaitForEndOfFrame();
        }


        isKillable = true;
    }



	// Update is called once per frame
	void Update () {
        amTime = amTime + Time.deltaTime;


        
            




        

	}
}
