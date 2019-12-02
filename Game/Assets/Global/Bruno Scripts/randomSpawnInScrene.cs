using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawnInScrene : MonoBehaviour
{
    public double maxX;
    public double minX;
    public double maxY;
    public double minY;
    public double startTime;
    public double timeInterval;
    public double endTime;
    public GameObject spawned;

    private double amTime;

    public double GetRandomNumber(double minimum, double maximum)
    {   
        return Random.Range((float)minimum, (float)maximum);
    }

    IEnumerator spawn(){
        yield return new WaitForSeconds((float)startTime);    
        
        while(endTime > amTime){
            double x = GetRandomNumber(minX,maxX);
            double y = GetRandomNumber(minY,maxY);

            Vector3 pos = new Vector3((float)x,(float)y,-9f);
            Quaternion angle = Quaternion.Euler(0f, 0f, 0f);

            Instantiate(spawned, pos, angle);

            yield return new WaitForSeconds((float)timeInterval);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawn");
    }

    // Update is called once per frame
    void Update()
    {
        amTime = amTime + Time.deltaTime;
    }
}
