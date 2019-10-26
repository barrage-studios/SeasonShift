using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private double runTime = 0;
    public static GameData _instance; // Track instances of this class
    void Start()
    {
        if (_instance != null) // If we exist, block creation
        {
            Destroy(this.gameObject);
            // Debug.LogError("Tried to instace the game manager twice!");
            return;
        }
        else // If we don't exist, Create ourselves
        {
            _instance = this;
            DontDestroyOnLoad(_instance.gameObject); // Block deletion
        }
    }
    private void FixedUpdate()
    {
        runTime += UnityEngine.Time.deltaTime;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneEngine.PeekStack() == 0)
                SceneEngine.PushScene(SceneEngine.Scenes.MENU);
            else
                SceneEngine.PushScene(SceneEngine.Scenes.GAME);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneEngine.PopScene();
        }
    }
    public void SaveData()
    {
        Debug.Log("Runtime [" + runTime + "]");
    }
}
