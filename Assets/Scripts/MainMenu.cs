using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject main;
    public GameObject levelSelect;
    public GameObject options;
    // Start is called before the first frame update
    void Awake()
    {
        main.SetActive(true);
        levelSelect.SetActive(false);
        options.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Back()
    {
        levelSelect.SetActive(false);
        options.SetActive(false);
        main.SetActive(true);
    }

    public void Play()
    {
        main.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
