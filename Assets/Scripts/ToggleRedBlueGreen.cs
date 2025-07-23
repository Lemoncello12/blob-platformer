using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRedBlueGreen : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    public GameObject green;
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
            Invoke("Toggle", interval);
        }
    }

    void Toggle()
    {
        isToggling = false;
        if (red.activeSelf == true)
        {
            red.SetActive(false);
            blue.SetActive(true);
            green.SetActive(false);
        }
        else if (blue.activeSelf == true)
        {
            red.SetActive(false);
            blue.SetActive(false);
            green.SetActive(true);
        }
        else
        {
            red.SetActive(true);
            blue.SetActive(false);
            green.SetActive(false);
        }
    }
}
