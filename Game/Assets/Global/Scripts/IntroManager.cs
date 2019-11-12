using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroManager : MonoBehaviour
{
    public Image CompanySplash;
    private bool hitFullView = false;
    private void Start()
    {
        Color color = CompanySplash.color;
        color.a = 0f;
        CompanySplash.color = color;
    }
    void FixedUpdate()
    {
        Color color = CompanySplash.color;
        if (!hitFullView)
        {
            Debug.Log("Fading in! a[" + color.a.ToString() + "]");
            color.a += (1.5f / 255f);
            if (color.a > (252f / 255f))
            {
                hitFullView = true;
            }
        }
        else
        {
            Debug.Log("Fading out! a[" + color.a.ToString() + "]");
            color.a -=  (1.5f / 255f);
            if (color.a < (4f / 255f))
            {
                SceneEngine.PushScene(SceneEngine.Scenes.MENU);
            }
        }
        CompanySplash.color = color;
    }
}
