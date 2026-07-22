using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSave : MonoBehaviour
{
    public int[] levelNumCheck = new int[12]; //Checkpoint number by level
    public bool[] collectibleGot = new bool[12];
    public int character = 0;

    private int currentScene;

    void Awake() //Loads save data, gets current scene;
    {
        LoadPlayer();
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void SavePlayer() //Saves save data;
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() //Saves variables to file via PlayerData and SaveSystem
    {
        PlayerData data = SaveSystem.LoadPlayer();

        character = data.character;
        levelNumCheck = data.levelNumCheck;
    }

    public void ResetPlayer() //Deletes save data
    {
        SaveSystem.DeletePlayer();
        SceneManager.LoadScene(0);
    }

    public void RestartLevel() //Saves that no checkpoint has been reached, loads current scene
    {
        levelNumCheck[currentScene] = 0;
        SavePlayer();

        Time.timeScale = 1;

        SceneManager.LoadScene(currentScene);
    }

    public void RestartFromCheckpoint() //Loads current scene
    {
        SavePlayer(); //Probably redudant

        Time.timeScale = 1;

        SceneManager.LoadScene(currentScene);
    }

    public int GetCharID()
    {
        return character;
    }

    public void SetCharID(int chara)
    {
        character = chara;
    }

    public int GetCheckpointNum()
    {
        return levelNumCheck[currentScene];
    }

    public void SetCheckpointNum(int check)
    {
        levelNumCheck[currentScene] = check;
    }
}
