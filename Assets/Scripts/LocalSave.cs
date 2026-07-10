using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSave : MonoBehaviour
{
    public int[] levelNumCheck = new int[12]; //Checkpoint number by level
    public int character = 0;
    public bool hasWizard = false; //Vestigial code
    public bool hasCommunist = false;

    private int currentScene;

    void Awake()
    {
        LoadPlayer();
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        character = data.character;
        levelNumCheck = data.levelNumCheck;
    }

    public void ResetPlayer()
    {
        SaveSystem.DeletePlayer();
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        levelNumCheck[currentScene] = 0;
        SavePlayer();

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
