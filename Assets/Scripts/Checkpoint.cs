using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite sprite;
    public CameraController cam;
    public GameObject abyss;

    [SerializeField] private float camY;
    [SerializeField] private float abyssY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlobController>() != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprite;
            collision.GetComponent<BlobController>().respawn = this.transform.position;
            abyss.transform.position = new Vector2(abyss.transform.position.x, abyssY);
            cam.MoveUp(camY);
        }
    }
}
