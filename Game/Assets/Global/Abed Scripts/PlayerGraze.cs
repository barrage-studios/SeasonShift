using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraze : MonoBehaviour
{
    public float grazeDelay; // Delay between each point of graze

    private float nextGraze = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bullet" && playerManager.isKillable == true && Time.time > nextGraze)
        {
            nextGraze = Time.time + grazeDelay;
            UICounterStatic.UIScript.updateGraze(1);
        }
    }

}
