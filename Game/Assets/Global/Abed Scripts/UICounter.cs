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
    public int pointsLifeReward; // Gain an extra life for every X amount of points earned
    public GameObject initialspawnPos;
    public GameObject playerPrefab;

    private int score;
    private int life;
    private int graze;
    private int bomb;
    private bool check;

    private void Start()
    {
        bool check = true;
        score = 0;
        life = 5;
        graze = 0;
        bomb = 2;
        scoreText.text = "" + score;
        lifeText.text = "" + life;
        grazeText.text = "" + graze;
        bombText.text = "" + bomb;
        UICounterStatic.UIScript = this;
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

    public void updateLife(int am)
    {
        if(check){
            life = 5;
            check = false;
        }

        Debug.Log(life);
        life += am;
        lifeText.text = life.ToString();
        if (life <= 0)
            StartCoroutine("gameOver");
        else
        {
            Vector3 pos = new Vector3(initialspawnPos.GetComponent<Transform>().position.x, initialspawnPos.GetComponent<Transform>().position.y, -10f);
            Quaternion angle = Quaternion.Euler(0f, 0f, 0f);
            Instantiate(playerPrefab, pos, angle);
        }

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

        SceneManager.LoadScene("Death");

    }
}
