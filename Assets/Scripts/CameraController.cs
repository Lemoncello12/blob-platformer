using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform center; //Blob's position
    private float moveY;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(center.position.x, transform.position.y, transform.position.z); //Moves with player

        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, moveY, transform.position.z), Time.deltaTime * 5); //Moves vertically due to MoveUp function
        }

        if(transform.position.y == moveY)
        {
            moving = false;
        }
    }

    public void MoveUp(float y) //Moves vertically, called by checkpoint
    {
        moveY = y;
        moving = true;
    }
}
