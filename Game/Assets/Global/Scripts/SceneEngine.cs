using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneEngine
{
    public enum Scene
    {
        INTRO,
        MENU,
        GAME
    }
    private static Dictionary<Scene, string> SceneList = new Dictionary<Scene, string>
    {
        { Scene.INTRO, "IntroScene" },
        { Scene.MENU, "MenuScene" },
        { Scene.GAME, "GameScene" }
    };
    private static Stack<Scene> StateStack = new Stack<Scene>(new Scene[] { Scene.INTRO });
    public static Scene PeekStack()
    {
        return StateStack.Peek();
    }
    public static void PopScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            StateStack.Pop();
            SceneManager.LoadScene(SceneList[StateStack.Peek()]);
        }
        else
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
    public static void PushScene(Scene scene)
    {
        if (!StateStack.Contains(scene))
        {
            StateStack.Push(scene);
            SceneManager.LoadScene(SceneList[scene]);
        }
        else if (StateStack.Count == SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("All scenes pushed");
        }
        else
        {
            Debug.LogWarning("Scene [" + scene.ToString() + "] already exists");
        }
    }
}