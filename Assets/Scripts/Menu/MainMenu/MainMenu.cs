using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{   
    [SerializeField]
    private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField]
    private Button newGameButton;
    [SerializeField]
    private Button loadGameButton;
    public void NewGame()
    {
        saveSlotsMenu.ActivateMenu(false);
    }

    public void LoadGame()
    {
        saveSlotsMenu.ActivateMenu(true);
    }

    public void Start()
    {
        if(!DataPersistenceManager.instance.HasGameData())
        {
            loadGameButton.interactable = false;
        }
        
    }

    

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        loadGameButton.interactable = false;
    }
}
