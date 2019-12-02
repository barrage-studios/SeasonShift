using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWave : MonoBehaviour
{
    public bool repBulTimeCAngle = false;
    public bool repBulTime = false;
    public bool repBulCircle = false;
    public bool rotCircle = false;

    public GameObject box;  //object you want spawned goes in here
    public float timeDelay = 0.0f;
    public float xAxis = 0.0f;  // Determines where it will spawn in the x axis
    public float yAxis = 0.0f;  // Determines where it will spawn in the y axis
    public float zRotation = 0.0f;  // Rotation counter clockwise 
    public float timeInterval = 0.0f;
    public float endTime = 0.0f;
    public float changeInAngle = 0.0f;
    public int circleSpokes = 0;

    
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private float amTime = 0.0f;



    void Start()
    {
        if (repBulTime)
        {
            StartCoroutine("repeatingBullets");
        }
        else if (rotCircle)
        {
            StartCoroutine("rotCircle1");
        }
        else if (repBulTimeCAngle)
        {
            StartCoroutine("repeatingBulletsCAngle");
        }
        else if (repBulCircle)
        {
            StartCoroutine("repeatingCircle");
        }
        else
        {
            StartCoroutine("Normal");
        }
    }


    /// <summary>
    /// ///////////////////
    /// </summary>
    /// <returns></returns>

    IEnumerator rotCircle1()
    {
        yield return new WaitForSeconds(timeDelay);
        float circleAngle = 360 / circleSpokes;
        Vector3 position = new Vector3(xAxis, yAxis, 0.0f);


        float newZrotation = zRotation;

        while (amTime <= endTime)
        {
            yield return new WaitForSeconds(timeInterval);

            //Instantiate(box, (spawner.transform.position), Quaternion.Euler(xRotation, yRotation, newZrotation));

            newZrotation = zRotation + circleAngle;

            for (int i = 0; i < circleSpokes; i++)
            {
                Instantiate(box, position, (Quaternion.Euler(xRotation, yRotation, newZrotation)));

                newZrotation = newZrotation + circleAngle;
            }

            zRotation = zRotation + changeInAngle;
        }


    }
    /// <summary>
    /// ///////////////////////////////////////
    /// </summary>
    /// <returns></returns>


    IEnumerator repeatingCircle()
    {
        yield return new WaitForSeconds(timeDelay);
        float circleAngle = 360 / circleSpokes;
        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation);
        Vector3 position = new Vector3(xAxis, yAxis, 0.0f);

        
        


        while (amTime <= endTime)
        {
            yield return new WaitForSeconds(timeInterval);

            Instantiate(box, position, angle);

            float newZrotation = zRotation + circleAngle;

            for (int i = 1; i < circleSpokes; i++)
            { 
                Instantiate(box, position, (Quaternion.Euler(xRotation, yRotation, newZrotation)));

                newZrotation = newZrotation + circleAngle;
            }
                

        }

    }


    IEnumerator repeatingBullets()
    {
        yield return new WaitForSeconds(timeDelay);
        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation);
        Vector3 position = new Vector3(xAxis, yAxis, 0.0f);

        //float lastTime = amTime;

        while (amTime <= endTime)
        {
            yield return new WaitForSeconds(timeInterval);


            Instantiate(box, position, angle);

        }

    }



    IEnumerator repeatingBulletsCAngle()
    {
        yield return new WaitForSeconds(timeDelay);
        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation);
        Vector3 position = new Vector3(xAxis, yAxis, 0.0f);
        float angleC = changeInAngle;


        while (amTime <= endTime)
        {
            yield return new WaitForSeconds(timeInterval);

            Instantiate(box, position, angle);

            angle = Quaternion.Euler(xRotation, yRotation, (zRotation + angleC));

            angleC = angleC + changeInAngle;

        }



    }



    IEnumerator Normal()
    {
        yield return new WaitForSeconds(timeDelay);
        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation); // creating angle variable for object
        Vector3 postition = new Vector3(xAxis, yAxis, 0.0f);  // creating position variable for object

        Debug.Log("Its here"); //check to see if it works

        Instantiate(box, postition, angle);

    }

    // Update is called once per frame
    void Update()
    {
        amTime = amTime + Time.deltaTime;
    }
}
