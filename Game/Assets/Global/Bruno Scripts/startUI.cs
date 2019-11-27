using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUI : MonoBehaviour
{
    public GameObject levelManager;


    // Start is called before the first frame update
    void Start()
    {
        levelManager.GetComponent<UICounter>().startLife();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
