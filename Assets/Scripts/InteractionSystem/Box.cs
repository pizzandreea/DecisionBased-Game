using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{

    [SerializeField]
    private string _prompt;
    [SerializeField]
    private List<InventoryItemData> referenceItems;
    [SerializeField]
    private bool canOpen;

    public bool isInteractable => canOpen;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if(referenceItems != null)
        {
            foreach (InventoryItemData item in referenceItems)
                InventorySystem.InventoryInstance.Add(item);
            Debug.Log("Taken from box");
            referenceItems = null;
            canOpen = false;
            return true;

        }
        else { return false; }

    }
}
