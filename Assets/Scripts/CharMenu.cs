using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMenu : MonoBehaviour
{
    public LocalSave save;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;

    public void Start()
    {
        if (save.character == 0)
        {
            arrow1.SetActive(true);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }
        else if (save.character == 1)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(true);
            arrow3.SetActive(false);
        }
        else if (save.character == 2)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(true);
        }
    }
    public void CharacterSelect (int chara)
    {
        save.character = chara;
        save.SavePlayer();
        //capitalist 0, communist 1, wizard 2

        if (save.character == 0)
        {
            arrow1.SetActive(true);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }
        else if (save.character == 1)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(true);
            arrow3.SetActive(false);
        }
        else if (save.character == 2)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(true);
        }
    }
}
