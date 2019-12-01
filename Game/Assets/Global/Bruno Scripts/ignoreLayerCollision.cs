using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreLayerCollision : MonoBehaviour {


    public int layer1;
    public int layer2;


	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(layer1,layer2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
