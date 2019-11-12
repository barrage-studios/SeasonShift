using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour {

    public GameObject player;
    public GameObject bullets;
    public int playerBulletLayer;
    public int playerLayer;

    public float timeInterval = 0.5f;

    private bool check = true;
    private bool check2 = false;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(playerLayer, playerBulletLayer);
    }


    IEnumerator shooting() {

        yield return new WaitWhile(() => check);
        

        while (check2) {
            Quaternion angle = Quaternion.Euler(0, 0, 90);

            Instantiate(bullets, (player.transform.position), angle);

            yield return new WaitForSeconds(timeInterval);
            
        }


    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            check = false;
            check2 = true;
            StartCoroutine("shooting");
        }
        else if(Input.GetKeyUp(KeyCode.Z)) {
            check = true;
            check2 = false;
        }
        
	}
}
