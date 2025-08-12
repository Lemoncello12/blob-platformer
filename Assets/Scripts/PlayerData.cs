using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int[] levelNumCheck;
    public int character;
    public bool hasWizard;
    public bool hasCommunist;

    public PlayerData (LocalSave save) //Player player
    {
        levelNumCheck = save.levelNumCheck;
        character = save.character;
        hasWizard = save.hasWizard;
        hasCommunist = save.hasCommunist;
    }

}
