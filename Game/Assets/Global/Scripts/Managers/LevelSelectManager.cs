using System.Collections;
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
    public void SelectLevel(int level)
    {

    }
}
