using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Profile
{
    string name = "Player";
    float playtime = 0.0f;
    
    public Profile(string name, float playtime)
    {
        if (name.Length > 10)
        {
            Debug.LogError("Name value [" + name + "] is too long (>10), setting default name");
            this.name = "Player";
        }
        else
        {
            this.name = name;
        }
        if (playtime < 0.0)
        {
            Debug.LogError("Playtime is negative, only positive playtimes are possible");
            this.playtime = 0.0f;
        }
        else
        {
            this.playtime = playtime;
        }
    }
    public string getName()
    {
        return this.name;
    }
    public float getTime()
    {
        return this.playtime;
    }
}
