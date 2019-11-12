using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerLives : MonoBehaviour {

    public GameObject initialspawnPos;
    public GameObject playerPrefab;
    public int lives;
    public Text lifeCounter;

    public static int deathDetect = 0;
    public int startAm = 3;

	// Use this for initialization
	void Start () {
        lives = startAm;
        deathDetect = 0;
    }

    IEnumerator trueDeath()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Death");

    }
	
	// Update is called once per frame
	void Update () {
        if ((deathDetect > 0) & (lives > 0) & (playerInvincibility.isKillable)) {
            Vector3 pos = new Vector3(-5.41f, -8.69f, 0f);
            Quaternion angle = Quaternion.Euler(0f,0f,0f);

            if (lives > 0)
            {
                Instantiate(playerPrefab, pos, angle);
                deathDetect -= 1;
                lives = lives - 1;
                
            }
            
            
        }

        if(lives <= 0 && deathDetect == 1){
            StartCoroutine("trueDeath");
        }





        lifeCounter.GetComponent<UnityEngine.UI.Text>().text = lives.ToString();

    }
}
