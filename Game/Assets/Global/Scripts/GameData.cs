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
            playerProfile = LoadData();
            if (playerProfile == null)
                playerProfile = new Profile("Player", 0.0f);
        }
    }
    private void FixedUpdate()
    {
        if (SceneEngine.PeekStack().Equals(SceneEngine.Scenes.MENU))
            playTime += UnityEngine.Time.deltaTime;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneEngine.PeekStack().Equals(SceneEngine.Scenes.INTRO))
                SceneEngine.PushScene(SceneEngine.Scenes.MENU);
            else
                SceneEngine.PushScene(SceneEngine.Scenes.GAME);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneEngine.PopScene();
        }
    }
    public float getTime()
    {
        return this.playTime;
    }
    public Profile LoadData()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("No Player profile exists, will create one on save");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        Profile profile = (Profile)bf.Deserialize(file);
        file.Close();

        return profile;
    }
    public void SaveData()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        Profile profile = new Profile(playerProfile.getName(), playTime + playerProfile.getTime());
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, profile);
        file.Close();
    }
}
