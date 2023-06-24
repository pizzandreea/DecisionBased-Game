using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    
    
    private SaveSlot[] saveSlots;
    [Header("Confirmation Popup")]
    [SerializeField]
    private ConfirmationPopUpMenu confirmationPopUpMenu;

    private bool isLoadingGame = false;
    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }
    
    public void ActivateMenu(bool _isLoadingGame)
    {
        isLoadingGame = _isLoadingGame;


        // load all of the profiles that exist
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();

        // for each save slot, set the data and the content
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            // get the profile id
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            // displays the data in the save slot
            saveSlot.SetData(profileData);

            if(profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
            }
        }

    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        //disable all buttons
        DisableMenuButtons();
        
        // case 1 - Loading game
        if (isLoadingGame)
        {
            DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            SaveGameAndLoadScene();

        }
        // case 2 - start a new game but the savesclot has data
        else if (saveSlot.hasData)
        {
            // we want to show the conf popup
            confirmationPopUpMenu.ActivateMenu(
                "Crearea unui joc nou folosind acest slot va sterge save-ul precedent. Esti sigur ca vrei sa continui?",
                // function if clicked yes
                () => {
                    DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    DataPersistenceManager.instance.NewGame();
                    SaveGameAndLoadScene();
                },
                // function if clicked no
                () => {
                    ActivateMenu(isLoadingGame);
                    
                }
            );
        }
        // case 3 new game on empty slot
        else 
        {
            DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    DataPersistenceManager.instance.NewGame();
                    SaveGameAndLoadScene();
        }
        
        
    }

    private void SaveGameAndLoadScene()
    {
        //save the game anytime  before a new scene is loaded
        DataPersistenceManager.instance.SaveGame();
        //load the scene 
        SceneManager.LoadSceneAsync("1 Village"); 
    }
    private void DisableMenuButtons()
    {
        foreach(SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
    }
    
}
