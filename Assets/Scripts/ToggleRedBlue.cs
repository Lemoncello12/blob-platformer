using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRedBlue : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    [SerializeField] private float interval;

    private bool isToggling = false;
    // Start is called before the first frame update
    void Start()
    {
        blue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isToggling)
        {
            isToggling = true;
            Invoke("Toggle", interval); //Toggles after given seconds
        }
    }

    void Toggle() //Self-explanatory
    {
        isToggling = false;
        if (red.activeSelf == true)
        {
            red.SetActive(false);
            blue.SetActive(true);
        }
        else
        {
            red.SetActive(true);
            blue.SetActive(false);
        }
    }
}
