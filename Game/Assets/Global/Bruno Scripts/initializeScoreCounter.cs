using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initializeScoreCounter : MonoBehaviour {

    public Text scoreCounter;

    public static int lev1ScoreCounter = 0;
    

	// Use this for initialization
	void Start () {
        scoreCounter.GetComponent<UnityEngine.UI.Text>().text = 0.ToString();	
	}
	
	// Update is called once per frame
	void Update () {
        scoreCounter.GetComponent<UnityEngine.UI.Text>().text = lev1ScoreCounter.ToString();

    }
}
