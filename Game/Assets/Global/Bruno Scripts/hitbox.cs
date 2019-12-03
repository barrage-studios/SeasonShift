using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public GameObject playerprefab;
    private float amTime = 0;
    
    void Update(){
        amTime = amTime + Time.deltaTime;
        while(amTime < 6){
            GetComponent<CircleCollider2D>().enabled = false;
        }
        GetComponent<CircleCollider2D>().enabled = true;
    }
    
    void Start(){
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if ((col.gameObject.layer == 11))
        {
            if(this.gameObject.layer == 8){        
                Debug.Log("play lay: " + this.gameObject.layer);
                Destroy(col.gameObject);
                playerprefab.GetComponent<playerManager>().deathD();  
            }
            
            
        }
        if((col.gameObject.layer == 12)||(col.gameObject.layer == 13)){
            if(this.gameObject.layer == 8){        
                Debug.Log("play lay: " + this.gameObject.layer);
                playerprefab.GetComponent<playerManager>().deathD();  
            }
        }

    }
}
