using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkBossDeath : MonoBehaviour {


    public static int boss1death = 0;


    private int bossdeath;

	// Use this for initialization
	void Start () {
        bossdeath = boss1death;
	}


    IEnumerator endLevel() {

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("LevelSelect");

    }

	
	// Update is called once per frame
	void Update () {
        if (boss1death > bossdeath) {
            StartCoroutine("endLevel");
        }
	}
}
