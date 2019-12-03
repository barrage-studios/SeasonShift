using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public Text nameText;
    public Text playtimeText;
 
    void Start()
    {
        nameText.text = GameData._instance.playerProfile.getName();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneEngine.PopScene();
        }
    }
    void FixedUpdate()
    {
        playtimeText.text = GameData._instance.getTime().ToString();
    }
    // Button Functions
    public void PlayClicked()
    {
        SceneEngine.PushScene(SceneEngine.Scenes.LEVEL);
    }
    public void SettingsClicked()
    {
        Debug.Log("No implementation of settings yet!");
    }
    public void ProfilesClicked()
    {
        Debug.Log("No implementation of profiles yet!");
    }
    public void ExitClicked()
    {
        SceneEngine.CloseApp();
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
