using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimedAngle : MonoBehaviour
{

    public GameObject bullet;   ///what is going to be fired
    public GameObject spawner;  ///where it is going to spawn from
    public GameObject player;  ///the actual player

    public float timeDelay;  /// amount of time before the bullets begin to appear
    public float timeInterval;  /// amount of time between the bullets appearing
    public float endTime; /// when the bullets will stop spawning(counts from when it spawns)

    private float amTime;
    private float xRotation = 0;
    private float yRotation = 0;

    private Vector3 playerVec;
    private Vector3 spawnVec;

    private float degree;
    


    IEnumerator repBullets()
    {
        yield return new WaitForSeconds(timeDelay);

        Vector3 playerVec = player.transform.position;


        Vector3 spawnVec = spawner.transform.position;

        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float spawnerX = spawner.transform.position.x;
        float spawnerY = spawner.transform.position.y;

        // Math.Atan2(target.y - me.y, target.x - me.x) * (180/Math.PI)
        float degree = Mathf.Atan2(playerY - spawnerY, playerX - spawnerX) * (180 / Mathf.PI);

        Debug.Log(degree);
        

        


        Quaternion angle = Quaternion.Euler(xRotation, yRotation, degree);  //angle is found before the spawning so it is set once

        float startTime = amTime;

        while (amTime <= (startTime + endTime))
        {
            yield return new WaitForSeconds(timeInterval);


            Instantiate(bullet, (spawner.transform.position), angle); /// the actual spawning functions

        }



    }


    // Start is called before the first frame update
    void Start()
    {

        spawnVec = Vector3.zero;
        


        StartCoroutine("repBullets");
    }

    // Update is called once per frame
    void Update()
    {

        float amTime =+ Time.deltaTime;
    }
}
