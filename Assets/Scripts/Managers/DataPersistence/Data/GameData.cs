using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;

    

    public GameData()
    {
        playerPosition = new Vector3(0, -10.7f, 0);
    }
}
