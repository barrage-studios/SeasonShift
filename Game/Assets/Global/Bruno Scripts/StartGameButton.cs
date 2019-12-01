using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public Button StartButton;

    private void Start()
    {
        Button btn = StartButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
