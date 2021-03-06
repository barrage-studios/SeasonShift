﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroManager : MonoBehaviour
{
    public Image[] Splashes;
    private int currentSplash = 0;
    private bool hitFullView = false;
    private void Start()
    {
        foreach (Image splash in Splashes)
        {
            Color color = splash.color;
            color.a = 0f;
            splash.color = color;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneEngine.PopScene();
        }
        else if (Input.anyKeyDown)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Input.GetMouseButtonDown(i))
                {
                    return;
                }
            }
            if (currentSplash == Splashes.Length - 1)
            {
                SceneEngine.PushScene(SceneEngine.Scenes.MENU);
            }
            Splashes[currentSplash].color = new Color(0, 0, 0, 0);
            currentSplash++;
            hitFullView = false;
        }
    }
    void FixedUpdate()
    {
        Color color = Splashes[currentSplash].color;
        if (!hitFullView)
        {
            //Debug.Log("Fading in! a[" + color.a.ToString() + "]");
            color.a += (1.5f / 255f);
            if (color.a > (252f / 255f))
            {
                hitFullView = true;
            }
        }
        else
        {
            //Debug.Log("Fading out! a[" + color.a.ToString() + "]");
            color.a -=  (1.5f / 255f);
            if (color.a < (4f / 255f) && (currentSplash < Splashes.Length - 1))
            {
                currentSplash++;
                hitFullView = false;
                return;
            }
            else if (color.a < (4f / 255f) && (currentSplash == Splashes.Length - 1))
            {
                SceneEngine.PushScene(SceneEngine.Scenes.MENU);
            }
        }
        Splashes[currentSplash].color = color;
    }
}
