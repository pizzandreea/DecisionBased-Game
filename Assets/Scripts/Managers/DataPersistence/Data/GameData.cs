using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public long lastUpdated;
    public Vector3 playerPosition;
    public string currentDateTime;
    //to do add more data to save
    // public int playerHealth;


    // inventory items
    //public Dictionary<InventoryItemData, InventoryItem> itemDictionary;

    public List<InventoryItem> inventory; 
    


    // world items collected
    public SerializableDictionary<string, bool> itemsCollected;
    

    

    public GameData()
    {
        currentDateTime = System.DateTime.Now.ToString();
        playerPosition = new Vector3(0, -10.7f, 0);
        inventory = new List<InventoryItem>();
        itemsCollected = new SerializableDictionary<string, bool>();
    }
}
