﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneEngine
{
    public enum Scenes
    {
        INTRO,
        MENU,
        GAME
    }
    private static Dictionary<Scenes, string> SceneList = new Dictionary<Scenes, string>
    {
        { Scenes.INTRO, "IntroScene" },
        { Scenes.MENU, "MenuScene" },
        { Scenes.GAME, "GameScene" }
    };
    private static Stack<Scenes> SceneStack = new Stack<Scenes>(new Scenes[] { Scenes.INTRO });
    public static Scenes PeekStack()
    {
        return SceneStack.Peek();
    }
    public static void PopScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneStack.Pop();
            SceneManager.LoadScene(SceneList[SceneStack.Peek()]);
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
    public static void PushScene(Scenes scene)
    {
        if (!SceneStack.Contains(scene))
        {
            SceneStack.Push(scene);
            SceneManager.LoadScene(SceneList[scene]);
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
}