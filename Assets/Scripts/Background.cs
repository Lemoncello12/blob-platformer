using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public int numRight;
    public int numUp;
    public GameObject background;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < numRight; i++)
        {
            for (int a = 0; a < numUp; a++)
            {
                Instantiate(background, new Vector3(i * 48 + transform.position.x, a * 27 + transform.position.y, transform.position.z), Quaternion.identity);
            } 
        }
    }
}
