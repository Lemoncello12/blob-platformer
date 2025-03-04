using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Apple;

public class SawMove : MonoBehaviour
{
    [SerializeField] private bool axisIsY;
    [SerializeField] private bool invert;

    [SerializeField] private float speed;
    [SerializeField] private float max;
    [SerializeField] private float delay;

    private Vector2 original;
    private bool moving = false;
    private int flip;
    // Start is called before the first frame update
    void Start()
    {
        original = transform.position;

        if (invert)
        {
            flip = -1;
        }
        else
        {
            flip = 1;
        }
        Invoke("StartMoving",delay);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (axisIsY)
            {
                transform.position = new Vector2(transform.position.x, flip * Mathf.PingPong(Time.time * speed, max) + original.y);
            }
            else
            {
                transform.position = new Vector2(flip * Mathf.PingPong(Time.time * speed, max) + original.x, original.y);
            }
        }
    }

    void StartMoving()
    {
        moving = true;
    }
}
