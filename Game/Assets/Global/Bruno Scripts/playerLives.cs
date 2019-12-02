using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLives : MonoBehaviour {

    public GameObject initialspawnPos;
    public GameObject playerPrefab;
    public int lives;
    public static int points = 0;
    public static int bombs = 2;
    public static int graze = 0;
    public Text bombCounter;
    public Text grazeCounter;
    public Text pointCounter;
    public Text lifeCounter;

    public static int deathDetect = 0;
    public static int bossD = 0;
    public int startAm = 3;

	// Use this for initialization
	void Start () 
    {
        bombs = 2;
        lives = 3;
        lives = startAm;
        deathDetect = 0;
    }

    public IEnumerator trueDeath()
    {
        yield return new WaitForSeconds(5f);

        SceneEngine.PopScene();
    }

    // Update is called once per frame
    void Update()
    {
        if ((deathDetect > 0) & (lives > 0) & (playerManager.isKillable))
        {
            float xpos = initialspawnPos.GetComponent<Transform>().position.x;
            float ypos = initialspawnPos.GetComponent<Transform>().position.y;
            Vector3 pos = new Vector3(xpos, ypos, -10f);
            Quaternion angle = Quaternion.Euler(0f, 0f, 0f);

            if (lives > 0)
            {
                Instantiate(playerPrefab, pos, angle);
                deathDetect -= 1;
                lives = lives - 1;
            }
        }

        if (lives <= 0 && deathDetect == 1)
        {
            StartCoroutine("trueDeath");
        }

        pointCounter.GetComponent<UnityEngine.UI.Text>().text = points.ToString();
        lifeCounter.GetComponent<UnityEngine.UI.Text>().text = lives.ToString();
        grazeCounter.GetComponent<UnityEngine.UI.Text>().text = graze.ToString();
        bombCounter.GetComponent<UnityEngine.UI.Text>().text = bombs.ToString();
    }
    private void OnDestroy()
    {
        GameData._instance.playerProfile.addScore(points);
    }
}
