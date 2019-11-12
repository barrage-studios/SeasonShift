using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkBoss3Death : MonoBehaviour {


    public static int boss3death = 0;


    private int bossdeath;
    // Use this for initialization
    void Start () {
        bossdeath = boss3death;
    }

    IEnumerator endLevel()
    {

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("LevelSelect");

    }

    // Update is called once per frame
    void Update () {
        if (boss3death > bossdeath)
        {
            StartCoroutine("endLevel");
        }
    }
}
