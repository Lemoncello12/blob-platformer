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
        for (int i = 1; i <= numRight; i++)
        {
            Instantiate(background, new Vector3(i * 48 + transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
