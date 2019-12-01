using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public GameObject playerprefab;

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.layer == 11)
        {
            if(this.gameObject.layer == 8){        
                Debug.Log("play lay: " + this.gameObject.layer);
                Destroy(col.gameObject);
                playerprefab.GetComponent<playerManager>().deathD();  
            }
            
            
        }

    }
}
