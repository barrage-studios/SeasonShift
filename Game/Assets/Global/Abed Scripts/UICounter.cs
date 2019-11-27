using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICounter : MonoBehaviour
{
    public Text scoreText;
    public Text lifeText;
    public Text grazeText;
    public Text bombText;
    public int life;
    public int pointsLifeReward; // Gain an extra life for every X amount of points earned
    public GameObject initialspawnPos;
    public GameObject playerPrefab;

    private int score;
    private int graze;
    private int bomb;
    private int counter = 0;
    private bool check = true;

    private void Start()
    {
        counter = 0;
        check = true;
        score = 0;
        graze = 0;
        bomb = 2;
        scoreText.text = "" + score;
        lifeText.text = "" + life;
        grazeText.text = "" + graze;
        bombText.text = "" + bomb;
        //UICounterStatic.UIScript = this;
    }

    private void Awaken(){
        counter = 0;
    }

    void OnApplicationQuit(){
        counter = 0;
    }

    public void updateScore(int value)
    {
        score += value;
        scoreText.text = "" + score;
        if (score % pointsLifeReward == 0)
        {
            updateLife(1);
        }
    }

    public void startLife(){
        life = 5;
    }

    public void updateLife(int am)
    {
        Debug.Log("CountCheck: " + check);
        if(check){
            counter = 0;
            check = false;
        }
        counter = counter + am;
        life = life + counter;
        Debug.Log("Life: " + life);
        Debug.Log("AM: "+ am);
        Debug.Log("Count: "+ counter);
        lifeText.text = "" + life;
        if (life <= 0)
            StartCoroutine("gameOver");
        else
        {
            float xpos = initialspawnPos.GetComponent<Transform>().position.x;
            float ypos = initialspawnPos.GetComponent<Transform>().position.y;

            Vector3 pos = new Vector3( xpos, ypos, -10f);
            Quaternion angle = Quaternion.Euler(0f, 0f, 0f);
            Instantiate(playerPrefab, pos, angle);
        }
        check = true;
        am = 0;
    }

    public void updateGraze(int value)
    {
        graze += value;
        grazeText.text = "" + graze;
    }

    public void resetGraze()
    {
        graze = 0;
        grazeText.text = "0";
    }

    public void updateBomb(int value)
    {
        bomb += value;
        bombText.text = "" + bomb;
    }

    public bool bombCheck()
    {
        if (bomb == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("LevelSelect");

    }
}
