using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int[] levelNumCheck;
    public int character;

    public PlayerData (LocalSave save) //Player player
    {
        levelNumCheck = save.levelNumCheck;
        character = save.character;
    }

}
