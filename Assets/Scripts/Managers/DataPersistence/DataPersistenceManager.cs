using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField]
    private bool initializeDataIfNull = false;

    [Header("File Storage Config")]

    [SerializeField]
    private string fileName;
    [SerializeField]
    private bool useEncryption;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileId = "";
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more that one DataPersistence Manager");
            Destroy(this.gameObject);  
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        selectedProfileId = dataHandler.GetMostRecentlyUpdatedProfileId();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    

    public void ChangeSelectedProfileId(string newProfileId)
    {
        //update the profile we use for saving and loading
        selectedProfileId = newProfileId;
        //Load the game, which will  use that profile, updating  our gamedata accordingly
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // to do load any saved data from a file using data handler
        this.gameData = dataHandler.Load(selectedProfileId);

        // start a new game if the data is null and  we are configured  to initialize
        // data for debugging purposes
        if(this.gameData == null && initializeDataIfNull)
        {
            Debug.Log("no data found initializing new game");
            NewGame();
            return;
        }

        //if no data to load we initialize new game     

        if(this.gameData == null)
        {
            Debug.Log("no data found initializing new game");
            return;
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
            dataPersistenceObj.SaveData( gameData);
        }

        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        //Debug.Log("saved player position at" + gameData.playerPosition.ToString());
        // save that data to a file using the data handler

        dataHandler.Save(gameData, selectedProfileId);
    }


    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public bool HasGameData()
    {
        return this.gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
}
