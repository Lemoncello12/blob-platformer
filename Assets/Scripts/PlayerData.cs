using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int[] levelNumCheck;
    public bool hasWizard;
    public bool hasCommunist;

    public PlayerData (LocalSave save) //Player player
    {
        levelNumCheck = save.levelNumCheck;
        hasWizard = save.hasWizard;
        hasCommunist = save.hasCommunist;
    }

}
