using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropOnPlayerCircle : MonoBehaviour {


    public GameObject bullet;   ///what is going to be fired
    public GameObject spawner;  ///where it is going to spawn from
    public GameObject player;  ///the actual player


    
    public float timeInterval;  /// amount of time between the bullets appearing
    public float amountBullets; /// how many bullets the bomber should drop(it will continue moving)

    private float amTime;
    private float xRotation = 0;
    private float yRotation = 0;
    private float zRotation = 270;

    float chech = 0;

    IEnumerator bombDrop()
    {
        yield return new WaitForSeconds(0);



        float endTime = amTime + (amountBullets * timeInterval) + (float)0.1;

        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation);



        while (amTime < endTime)
        {

            Instantiate(bullet, (spawner.transform.position), angle);


            yield return new WaitForSeconds(timeInterval);


        }

        

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        amTime = amTime + Time.deltaTime;

        if (player.transform.position.x == spawner.transform.position.x)
        {

            chech = chech + 1;

            if (chech <= 1)
            {
                StartCoroutine("bombDrop");
            }

            

        }
	}
}
