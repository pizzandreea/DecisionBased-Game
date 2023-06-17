using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField]
    private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more that one DataPersistence Manager");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // to do load any saved data from a file using data handler
        this.gameData = dataHandler.Load();

        //if no data to load we initialize new game     

        if(this.gameData == null)
        {
            Debug.Log("no data found initializing new game");
            NewGame();
        }

        // to do push the loaded data to all other scripts that need it
        //dataPersistenceObjects = FindAllDataPersistenceObjects();
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded player position" +  gameData.playerPosition);
    }

    public void SaveGame()
    {
        // to do pass the data to other scripts so they can  update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        //Debug.Log("saved player position at" + gameData.playerPosition.ToString());
        // save that data to a file using the data handler

        dataHandler.Save(gameData);
    }


    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        Debug.Log("Tring");
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
