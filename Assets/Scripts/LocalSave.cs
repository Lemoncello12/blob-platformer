using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSave : MonoBehaviour
{
    public int[] levelNumCheck = new int[12];
    public int character = 0;
    public bool hasWizard = false;
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

        levelNumCheck = data.levelNumCheck;
        hasWizard = data.hasWizard;
        hasCommunist = data.hasCommunist;
    }

    public void ResetPlayer()
    {
        SaveSystem.DeletePlayer();
        SceneManager.LoadScene(0);
    }
}
