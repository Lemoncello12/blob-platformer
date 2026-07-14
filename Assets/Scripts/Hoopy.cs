using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public class Hoopy : MonoBehaviour
{
    public LocalSave save;
    public int sceneToLoad = 0;

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
        if (collision.GetComponent<BlobController>() != null) //On collision with Blob, load next scene if applicable
        {
            save.SetCheckpointNum(0);
            save.SavePlayer();
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
