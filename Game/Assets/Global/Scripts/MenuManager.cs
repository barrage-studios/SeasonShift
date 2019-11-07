using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public Text nameText;
    public Text playtimeText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = GameData._instance.playerProfile.getName();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playtimeText.text = GameData._instance.getTime().ToString();
    }
}
