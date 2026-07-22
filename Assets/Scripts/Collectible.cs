using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Collectible : MonoBehaviour
{
    public LocalSave save;
    public Sprite collectedSprite;
    public int collectibleNum = 2;

    private bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        if (save.collectibleGot[collectibleNum] == true)
        {
            collected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlobController>() != null) //On player interaction 
        {
            if (!collected)
            {

            }
        }
    }
}
