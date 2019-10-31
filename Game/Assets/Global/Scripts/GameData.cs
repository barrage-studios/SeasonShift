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
            if (SceneEngine.PeekStack().Equals(SceneEngine.Scenes.INTRO))
                SceneEngine.PushScene(SceneEngine.Scenes.MENU, false);
            else if (SceneEngine.PeekStack().Equals(SceneEngine.Scenes.MENU))
                SceneEngine.PushScene(SceneEngine.Scenes.GAME, false);
            else
                SceneEngine.PushScene(SceneEngine.Scenes.PAUSE, true);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (!SceneEngine.PeekAdditive().Equals(3))
                SceneEngine.PopScene(false);
            else
                SceneEngine.PopScene(true);
        }
    }
    public void SaveData()
    {
        Debug.Log("Runtime [" + runTime + "]");
    }
}
