using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField]
    private string id;

    [SerializeField]
    private bool collected = false;

    [SerializeField]
    public MeshRenderer meshRenderer;


    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    [SerializeField]
    private string _prompt;
    [SerializeField]
    public InventoryItemData referenceItem;
    [SerializeField]
    private bool canPickUp;

    public bool isInteractable => canPickUp;
    public string InteractionPrompt => _prompt;

    public void Awake(){
        
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void Update(){
        if(collected){
            meshRenderer.enabled = false;
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (referenceItem != null)
        {
            InventorySystem.InventoryInstance.Add(referenceItem);
            canPickUp = false;
            meshRenderer.enabled = false;
            collected = true;
            return true;
        }
        else{
            return false;
        }
    }
    public void StopInteract()
    {

    }


    public void LoadData(GameData gameData)
    {
        
        gameData.itemsCollected.TryGetValue(id, out collected);
        if(collected)
        {
            //that means it was collected
            meshRenderer.enabled = false;
            canPickUp = false;
            Debug.Log("Data loaded");
        }

    }

    public void SaveData( GameData gameData)
    {
        if(gameData.itemsCollected.ContainsKey(id))
        {
            Debug.Log("Data removed");
            gameData.itemsCollected.Remove(id);
        }
        //we remove it before we update it
        gameData.itemsCollected.Add(id, collected);
    }
}
