using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string _prompt;

    [SerializeField]
    private bool canInspect;
    [SerializeField]
    private bool isCollectable;

    [SerializeField]
    private InventoryItemData referenceItem;

    [SerializeField]
    private AudioObject clipToPlay;

    [SerializeField]
    private float duration;




    public bool isInteractable => canInspect;
    public string InteractionPrompt => _prompt;

    public void Start()
    {
        canInspect = true;
    }

    public bool Interact(Interactor interactor)
    {

        if(clipToPlay != null)
        {
            Sound.instance.Play(clipToPlay, duration);
        }


        if (isCollectable)
        {
            
            InventorySystem.InventoryInstance.Add(referenceItem);
            Destroy(gameObject); return true;
        }
        else
            return false;
    }

    public void StopInteract()
    {

    }
}
