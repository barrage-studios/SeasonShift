using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneEngine
{
    public static void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public static void PrevScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            Application.Quit();
        }
    }
    public static void LoadExactScene(int num)
    {
        if (num > 0 || num < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(num);
        }
        else
        {
            Debug.LogError("Scene [" + num + "] does not exist");
        }
    }
    public static void LoadExactScene(string str)
    {
        int num = SceneManager.GetSceneByName(str).buildIndex;
        if (num > 0 || num < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(num);
        }
        else
        {
            Debug.LogError("Scene [" + num + "][" + str + "] does not exist");
        }
    }
}