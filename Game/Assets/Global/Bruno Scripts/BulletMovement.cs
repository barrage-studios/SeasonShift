using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public Transform bullet;
    public float Yvelocity;
    public float Xvelocity;

    public bool changeMovementOnce = false;
    public float timeChange;
    public float SecYvelocity;
    public float SecXvelocity;

    public bool changeMoveTwice = false;
    public float secTimeChange;
    public float thirYvelocity;
    public float thirXVelocity;


    private float amTime = 0;

    void Start()
    {

        if (changeMovementOnce)
        {
            StartCoroutine("timeMove");
        }
        else if (changeMoveTwice)
        {
            StartCoroutine("threeMove");
        }
        else
        {
            StartCoroutine("defaultMove");
        }
    }


    IEnumerator threeMove()
    {
        yield return new WaitForSeconds(0);

        while (timeChange > amTime)
        {
            yield return new WaitForEndOfFrame();

            //movement on the y axis relative to the rotation of the object
            transform.position += transform.up * Time.deltaTime * Yvelocity;

            //movement on the x axis relative to the rotation of the object
            transform.position += transform.right * Time.deltaTime * Xvelocity;

        }
        while ((timeChange <= amTime) && (secTimeChange > amTime))
        {
            yield return new WaitForEndOfFrame();
            transform.position += transform.up * Time.deltaTime * SecYvelocity;
            transform.position += transform.right * Time.deltaTime * SecXvelocity;
        }
        while (secTimeChange <= amTime)
        {
            yield return new WaitForEndOfFrame();
            transform.position += transform.up * Time.deltaTime * thirYvelocity;
            transform.position += transform.right * Time.deltaTime * thirXVelocity;

        }


    }




    IEnumerator defaultMove()
    {
        yield return new WaitForSeconds(0);

        while (true)
        {
            yield return new WaitForEndOfFrame();

            //movement on the y axis relative to the rotation of the object
            transform.position += transform.up * Time.deltaTime * Yvelocity;

            //movement on the x axis relative to the rotation of the object
            transform.position += transform.right * Time.deltaTime * Xvelocity;

        }

    }


    IEnumerator timeMove()
    {
        yield return new WaitForSeconds(0);


        while (timeChange > amTime)
        {
            yield return new WaitForEndOfFrame();

            //movement on the y axis relative to the rotation of the object
            transform.position += transform.up * Time.deltaTime * Yvelocity;

            //movement on the x axis relative to the rotation of the object
            transform.position += transform.right * Time.deltaTime * Xvelocity;

        }
        while (timeChange <= amTime)
        {
            yield return new WaitForEndOfFrame();
            transform.position += transform.up * Time.deltaTime * SecYvelocity;
            transform.position += transform.right * Time.deltaTime * SecXvelocity;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        amTime = amTime + Time.deltaTime;

    }
}
