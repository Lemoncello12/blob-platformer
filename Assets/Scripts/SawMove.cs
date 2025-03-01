using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Apple;

public class SawMove : MonoBehaviour
{
    [SerializeField] private bool axisIsY;
    [SerializeField] private float speed;
    [SerializeField] private float max;
    private Vector2 original;
    // Start is called before the first frame update
    void Start()
    {
        original = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (axisIsY)
        {
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time * speed, max) + original.y);
        }
        else
        {
            transform.position = new Vector2(Mathf.PingPong(Time.time * speed, max) + original.x, original.y);
        }
    }
}
