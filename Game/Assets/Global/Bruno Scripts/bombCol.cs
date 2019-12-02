using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombCol : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll){
        Debug.Log(coll.gameObject.layer);
        if(coll.gameObject.layer == 11){
            playerManager.isKillable = false;
            Destroy(coll.gameObject);
            
        }
        playerManager.isKillable = true;
    }

}
