using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNum = 1; //What number checkpoint this is; for saving
    
    public Sprite sprite; //Checkpoint sprite after reached by the player
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
        if (save.GetCharID() == 0)
        {
            sprite = capitalist;
        }
        else if (save.GetCharID() == 1)
        {
            sprite = communist;
        }
        else if (save.GetCharID() == 2)
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

            save.SetCheckpointNum(checkpointNum);
            save.SavePlayer();
        }
    }
}
