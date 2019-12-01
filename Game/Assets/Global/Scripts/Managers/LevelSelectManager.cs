using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public void SelectLevel(int level)
    {
        GameData._instance.setPlaying(true);
        switch (level)
        {
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
}
