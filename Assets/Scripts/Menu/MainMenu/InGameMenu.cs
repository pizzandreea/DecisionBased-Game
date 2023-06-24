using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    
    
    public void ExitGame()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Main Menu");
        
    }

    public void SaveGame()
    {
        DataPersistenceManager.instance.SaveGame();
    }


    
}
