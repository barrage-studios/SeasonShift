using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerExplosion : MonoBehaviour
{
    public int timeDelay;
    public int circleSpokes;
    public GameObject bullets;

    IEnumerator explosion(){
        yield return new WaitForSeconds(timeDelay);
        float circleAngle = 360 / circleSpokes;
        float newZrotation = 0;



        newZrotation = circleAngle;

        for (int i = 0; i < circleSpokes; i++)
        {
            Instantiate(bullets, (GetComponent<Transform>().position), (Quaternion.Euler(0f, 0f, newZrotation)));

            newZrotation = newZrotation + circleAngle;
        }
        Destroy(this.gameObject);
    }


    void Start()
    {
        StartCoroutine("explosion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
