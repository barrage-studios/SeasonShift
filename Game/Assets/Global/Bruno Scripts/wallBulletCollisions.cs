using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBulletCollisions : MonoBehaviour {

    public int playerBulletLayer;
    public int bulletLayer;

    public GameObject wall;

    void OnCollisionEnter2D(Collision2D col)
    {


        Debug.Log("OnCollisionEnter2D");

        if ((col.gameObject.layer == playerBulletLayer) || (col.gameObject.layer == bulletLayer))
        {
            
            Destroy(col.gameObject);
            
        }




    }
}
