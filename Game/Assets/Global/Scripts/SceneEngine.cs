using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneEngine
{
    private static Stack<int> StateStack = new Stack<int>(new[] { 0 });
    public static int PeekStack()
    {
        return StateStack.Peek();
    }
    public static void PopScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            StateStack.Pop();
            SceneManager.LoadScene(StateStack.Peek());
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
    public static void PushScene(string str)
    {
        int id = (SceneManager.GetSceneByName(str).IsValid()) ? SceneManager.GetSceneByName(str).buildIndex : -2;
        if (!StateStack.Contains(id))
        {
            StateStack.Push(id);
            SceneManager.LoadScene(id);
        }
        else if (id == -1)
        {
            Debug.LogError("Scene [" + str + "] does not exist");
        }
        else
        {
            Debug.LogError("Scene [" + id + "][" + str + "] already exists");
        }
    }
}