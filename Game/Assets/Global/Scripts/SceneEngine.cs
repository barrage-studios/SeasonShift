using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneEngine
{
    public enum Scenes
    {
        INTRO,
        MENU,
        LEVEL,
        SPRING,
        SUMMER,
        FALL,
        WINTER
    }
    private static Dictionary<Scenes, string> SceneList = new Dictionary<Scenes, string>
    {
        { Scenes.INTRO, "IntroScene" },
        { Scenes.MENU, "MenuScene" },
        { Scenes.LEVEL, "LevelSelect"},
        { Scenes.SPRING, "Spring"},
        { Scenes.SUMMER, "Summer"},
        { Scenes.FALL, "Fall"},
        { Scenes.WINTER, "Winter"}
    };
    private static Stack<Scenes> SceneStack = new Stack<Scenes>(new Scenes[] { Scenes.INTRO });
    public static Scenes PeekStack()
    {
        return SceneStack.Peek();
    }
    public static void PopScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            SceneStack.Pop();
            SceneManager.LoadScene(SceneList[SceneStack.Peek()]);
        }
        else
        {
            CloseApp();
        }
    }
    public static void PushScene(Scenes scene)
    {   
        if (SceneStack.Contains(scene))
        {
            Debug.LogError("Scene [" + scene.ToString() + "] already exists");
        }
        else if ( SceneStack.Contains(Scenes.SPRING) ||
                  SceneStack.Contains(Scenes.SUMMER) ||
                  SceneStack.Contains(Scenes.FALL) ||
                  SceneStack.Contains(Scenes.WINTER) )
        {
            Debug.LogError("Cannot push multiple levels at the same time!");
        }
        else
        {
            SceneStack.Push(scene);
            SceneManager.LoadScene(SceneList[scene]);
        }
    }
    public static void CloseApp()
    {
        GameData._instance.SaveData();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}