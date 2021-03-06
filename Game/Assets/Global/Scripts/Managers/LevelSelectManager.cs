﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public Button[] buttons;

    void Start()
    {
        for (int i = 0; i <= GameData._instance.playerProfile.getLevelsCleared(); i++)
        {
            buttons[i].interactable = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneEngine.PopScene();
        }
    }
    public void SelectLevel(int level)
    {
        GameData._instance.setPlaying(true);
        switch (level)
        {
            case 0:
                SceneEngine.PopScene();
                break;
            case 1:
                SceneEngine.PushScene(SceneEngine.Scenes.SPRING);
                break;
            case 2:
                SceneEngine.PushScene(SceneEngine.Scenes.SUMMER);
                break;
            case 3:
                SceneEngine.PushScene(SceneEngine.Scenes.FALL);
                break;
            case 4:
                SceneEngine.PushScene(SceneEngine.Scenes.WINTER);
                break;
        }
    }
    public void IsHovered(GameObject obj)
    {
        if (!obj.GetComponentInParent<Button>().interactable)
            return;

        Text text = obj.GetComponent<Text>();
        text.color = new Color(248, 255, 0);
    }
    public void IsUnHovered(GameObject obj)
    {
        if (!obj.GetComponentInParent<Button>().interactable)
            return;

        Text text = obj.GetComponent<Text>();
        text.color = new Color(255, 255, 255);
    }
}
