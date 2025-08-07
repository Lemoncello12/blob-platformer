using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSave : MonoBehaviour
{
    public int[] levelNumCheck = new int[12];
    public bool hasWizard = false;
    public bool hasCommunist = false;
    private int currentScene;

    void Awake()
    {
        LoadPlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
