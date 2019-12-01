using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombCol : MonoBehaviour
{
    public int enemyBulletLayer;

    void OnCollisionEnter2D(Collision2D coll){
        
        Debug.Log("coll");
        
        if(coll.gameObject.layer == enemyBulletLayer){
            Destroy(coll.gameObject);
        }
    }

}
