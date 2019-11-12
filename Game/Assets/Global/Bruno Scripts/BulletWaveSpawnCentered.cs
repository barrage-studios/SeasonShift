using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletWaveSpawnCentered : MonoBehaviour
{
    public bool repBulTimeCAngle = false;
    public bool repBulTime = false;
    public bool repBulCircle = false;
    public bool rotCircle = false;
    public bool coneShooting = false;

    public GameObject spawner;
    public GameObject box;  //object you want spawned goes in here
    public float timeDelay = 0.0f;
    public float zRotation = 0.0f;  // Rotation counter clockwise 
    public float timeInterval = 0.0f;
    public float endTime = 0.0f; 
    public float changeInAngle = 0.0f;
    public int circleSpokes = 0;
    public float startDegree = 0.0f; /// must be smaller than the endDegree
    public float endDegree = 0.0f;


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
        else if (coneShooting)
        {
            StartCoroutine("coneShot");
        }
        else
        {
            StartCoroutine("Normal");
        }
    }


    IEnumerator coneShot() 
    {
        yield return new WaitForSeconds(timeDelay);

        zRotation = startDegree;

        float degreeShifts = Math.Abs(endDegree - startDegree) / changeInAngle;
        int changes = 0;

        int check = 1;


        while (amTime < endTime)
        {
            switch (check)
            {
                case 1:
                    while (changes < degreeShifts)
                    {
                        yield return new WaitForSeconds(timeInterval);
                        Instantiate(box, (spawner.transform.position), (Quaternion.Euler(xRotation, yRotation, zRotation)));

                        zRotation = zRotation + changeInAngle;
                        changes = changes + 1;
                    }
                    check = 2;

                    break;

                case 2:
                    while (changes > 0)
                    {
                        yield return new WaitForSeconds(timeInterval);
                        Instantiate(box, (spawner.transform.position), (Quaternion.Euler(xRotation, yRotation, zRotation)));

                        zRotation = zRotation - changeInAngle;
                        changes = changes - 1;
                    }
                    check = 1;

                    break;

                default:

                    break;

            }



        }



    }





    IEnumerator rotCircle1()
    {
        yield return new WaitForSeconds(timeDelay);
        float circleAngle = 360 / circleSpokes;

        float newZrotation = zRotation;

        while (amTime <= endTime)
        {
            yield return new WaitForSeconds(timeInterval);

            //Instantiate(box, (spawner.transform.position), Quaternion.Euler(xRotation, yRotation, newZrotation));

            newZrotation = zRotation + circleAngle;

            for (int i = 0; i < circleSpokes; i++)
            {
                Instantiate(box, (spawner.transform.position), (Quaternion.Euler(xRotation, yRotation, newZrotation)));

                newZrotation = newZrotation + circleAngle;
            }

            zRotation = zRotation + changeInAngle;
        }


    }




    IEnumerator repeatingCircle()
    {
        yield return new WaitForSeconds(timeDelay);
        float circleAngle = 360 / circleSpokes;
        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation);
        

        while (amTime <= endTime)
        {
            yield return new WaitForSeconds(timeInterval);

            Instantiate(box, (spawner.transform.position), angle);

            float newZrotation = zRotation + circleAngle;

            for (int i = 1; i < circleSpokes; i++)
            {
                Instantiate(box, (spawner.transform.position), (Quaternion.Euler(xRotation, yRotation, newZrotation)));

                newZrotation = newZrotation + circleAngle;
            }


        }

    }


    IEnumerator repeatingBullets()
    {
        yield return new WaitForSeconds(timeDelay);
        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation);
        

        while (amTime <= endTime)
        {
            yield return new WaitForSeconds(timeInterval);


            Instantiate(box, (spawner.transform.position), angle);

        }

    }



    IEnumerator repeatingBulletsCAngle()
    {
        yield return new WaitForSeconds(timeDelay);
        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation);
        float angleC = changeInAngle;


        while (amTime <= endTime)
        {
            yield return new WaitForSeconds(timeInterval);

            Instantiate(box, (spawner.transform.position), angle);

            angle = Quaternion.Euler(xRotation, yRotation, (zRotation + angleC));

            angleC = angleC + changeInAngle;

        }



    }



    IEnumerator Normal()
    {
        yield return new WaitForSeconds(timeDelay);
        Quaternion angle = Quaternion.Euler(xRotation, yRotation, zRotation); // creating angle variable for object
        

        Instantiate(box, spawner.transform.position, angle);

    }

    // Update is called once per frame
    void Update()
    {
        amTime = amTime + Time.deltaTime;

    }
}
