using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    static GameData _instance; // Track instances of this class
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
            GameObject.DontDestroyOnLoad(this.gameObject); // Block deletion
        }
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

}
