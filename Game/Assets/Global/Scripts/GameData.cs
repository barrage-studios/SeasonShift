using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public Profile playerProfile = null;
    private bool playing = false;
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
        }
    }
    private void FixedUpdate()
    {
        if (playing) // Only add time in Menu Scene
            playerProfile.addPlaytime(UnityEngine.Time.deltaTime);
    }
    public float getTime()
    {
        return this.playerProfile.getTime();
    }
    public bool getPlaying()
    {
        return playing;
    }
    public void setPlaying(bool boolean)
    {
        playing = boolean;
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
            return new Profile();
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
        Debug.Log("Time elapsed in game is " + playerProfile.getTime().ToString());
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, playerProfile);
        file.Close();
    }
}
