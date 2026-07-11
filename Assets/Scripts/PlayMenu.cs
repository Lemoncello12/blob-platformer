using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update() //Opens menu, pauses time
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseMenu.activeSelf == false)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ExitMenu() //Exits menu, resumes time
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
