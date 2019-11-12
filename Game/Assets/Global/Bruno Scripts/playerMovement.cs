using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float Ospeed = 5;
    public float Tspeed = 3;

    public Transform obj;

    private float speed;

    private float modSpeed;

    public void Start(){
        modSpeed = Ospeed;
    }

    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        

        if (Input.GetButton("Fire3"))
        {
            speed = Tspeed;
            Debug.Log("Y");

            Vector3 tempVect = new Vector3(h, v, 0);

            tempVect = tempVect.normalized * speed * Time.fixedDeltaTime;

            

            obj.transform.position += tempVect;            
        }
        else{
            speed = Ospeed;
            Vector3 tempVect = new Vector3(h, v, 0);

            tempVect = tempVect.normalized * speed * Time.fixedDeltaTime;


            obj.transform.position += tempVect;


        }
        
        
        
        

        


        
        

    }
}
