using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public Profile playerProfile = null;
    private float playTime = 0;
    public static GameData _instance; // Track instances of this class
    void Start()
    {
        if (_instance != null) // If we exist, block creation
        {
            Destroy(this.gameObject);
            // Debug.LogError("Tried to instace the game manager twice!");
            return;
        }
        else // If we don't exist, Create ourselves
        {
            _instance = this;
            DontDestroyOnLoad(_instance.gameObject); // Block deletion
            playerProfile = LoadData(); // Load profile
            if (playerProfile == null) // If load fails create a fresh player
            {
                Debug.Log("Profile was null!");
                playerProfile = new Profile("Player", 0.0f);
            }
            playTime = playerProfile.getTime(); // Load in stored data
        }
    }
    private void FixedUpdate()
    {
        if (SceneEngine.PeekStack().Equals(SceneEngine.Scenes.MENU)) // Only add time in Menu Scene
            playTime += UnityEngine.Time.deltaTime;
    }
    public void Update()
    {
        if (SceneEngine.PeekStack().Equals(SceneEngine.Scenes.GAME))
        {
            if (Input.GetKeyDown(KeyCode.Return)) // Advance Scenes
            {
                if (SceneEngine.PeekStack().Equals(SceneEngine.Scenes.INTRO))
                    SceneEngine.PushScene(SceneEngine.Scenes.MENU);
                else
                    SceneEngine.PushScene(SceneEngine.Scenes.GAME);
            }
            else if (Input.GetKeyDown(KeyCode.Backspace)) // Drop scenes
            {
                SceneEngine.PopScene();
            }
        }
    }
    public float getTime()
    {
        return this.playTime;
    }
    public Profile LoadData() // Load in profile from file
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            Debug.Log("Player profile found");
            file = File.OpenRead(destination);
        }
        else
        {
            Debug.LogError("No Player profile exists, will create one on save");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        Profile profile = (Profile) bf.Deserialize(file);
        file.Close();
        Debug.Log("Time saved to file was " + profile.getTime().ToString());
        return profile;
    }
    public void SaveData() // Save profile to file
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            Debug.Log("File Found, overwriting save data");
            file = File.OpenWrite(destination);
        }
        else
        {
            Debug.Log("No save file found, creating new file");
            file = File.Create(destination);
        }
        Debug.Log("Time elapsed in game is " + playTime.ToString());
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, new Profile(playerProfile.getName(), playTime));
        file.Close();
    }
}
