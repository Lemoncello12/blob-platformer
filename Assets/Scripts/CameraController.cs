using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform center;
    private float moveY;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(center.position.x, transform.position.y, transform.position.z);

        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, moveY, transform.position.z), Time.deltaTime * 5);
        }

        if(transform.position.y == moveY)
        {
            moving = false;
        }
    }

    public void MoveUp(float y)
    {
        moveY = y;
        moving = true;
    }
}
