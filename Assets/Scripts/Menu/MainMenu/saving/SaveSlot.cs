using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header ("Profile")]
    [SerializeField]
    private string profileId = "";

    [Header("Content")]
    [SerializeField]
    private GameObject noDataContent;
    [SerializeField]
    private GameObject hasDataContent;

    [SerializeField]
    private TextMeshProUGUI dateText;
    private Button saveSlotButton;

    public bool hasData {get; private set;} = false;

    private void Awake()
    {
        saveSlotButton = GetComponent<Button>();
    }

    public void SetData(GameData gameData)
    {
        // if there is no data, show the no data content
        if(gameData == null)
        {
            hasData = false;
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            hasData = true;
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            dateText.text = gameData.currentDateTime.ToString();
        }
    }

    public string GetProfileId()
    {
        return profileId;
    }
    
    public void SetInteractable( bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }
}
