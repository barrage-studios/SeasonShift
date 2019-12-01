using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTopGraze : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D coll){
        
        if(coll.gameObject.layer == 11){
            playerLives.graze += 1;    
        }
    }
}
