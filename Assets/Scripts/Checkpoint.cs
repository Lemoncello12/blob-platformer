using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite sprite;
    public Sprite capitalist;
    public Sprite communist;
    public Sprite wizard;

    public LocalSave save;

    public CameraController cam;
    public GameObject abyss;

    [SerializeField] private float camY;
    [SerializeField] private float abyssY;
    
    // Start is called before the first frame update
    void Start()
    {
        if (save.character == 0)
        {
            sprite = capitalist;
        }
        else if (save.character == 1)
        {
            sprite = communist;
        }
        else if (save.character == 2)
        {
            sprite = wizard;
        }
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
