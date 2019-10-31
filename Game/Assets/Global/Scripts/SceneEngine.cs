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
        GAME,
        PAUSE
    }
    private static Dictionary<Scenes, string> SceneList = new Dictionary<Scenes, string>
    {
        { Scenes.INTRO, "IntroScene" },
        { Scenes.MENU, "MenuScene" },
        { Scenes.GAME, "GameScene" },
        { Scenes.PAUSE, "PauseScene" }
    };
    private static Stack<Scenes> SceneStack = new Stack<Scenes>(new Scenes[] { Scenes.INTRO });
    private static Stack<Scenes> AdditiveStack = new Stack<Scenes>();
    public static Scenes PeekStack()
    {
        return SceneStack.Peek();
    }
    public static Scenes PeekAdditive()
    {
        return AdditiveStack.Peek();
    }
    public static void PopScene(bool additive)
    {
        if (!additive)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneStack.Pop();
                SceneManager.LoadScene(SceneList[SceneStack.Peek()]);
            }
            else
            {
                CloseApp();
            }
        }
        else
        {
            if (AdditiveStack.Count > 0)
            {
                SceneManager.UnloadSceneAsync(SceneList[AdditiveStack.Peek()]);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneList[SceneStack.Peek()]));
                AdditiveStack.Pop();
            }
            else
            {
                Debug.LogError("Trying to pop additive scene when no additive scenes exist");
            }
        }
    }
    public static void PushScene(Scenes scene, bool additive)
    {
        if (!SceneStack.Contains(scene))
        {
            if (!additive)
            {
                SceneStack.Push(scene);
                SceneManager.LoadScene(SceneList[scene]);
            }
            else
            {
                AdditiveStack.Push(scene);
                SceneManager.LoadSceneAsync(SceneList[scene]);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneList[AdditiveStack.Peek()]));
            }
        }
        else if (SceneStack.Count == SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("All scenes pushed");
        }
        else
        {
            Debug.LogWarning("Scene [" + scene.ToString() + "] already exists");
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