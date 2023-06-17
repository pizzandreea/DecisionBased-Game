using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private NPCLookAt npcLookAt;
    private DialogueInteractable dialogueInteractable; 
    [SerializeField]
    private string _prompt;
    [SerializeField]
    private bool canTalk;

    public string InteractionPrompt => _prompt;
    public bool isInteractable => canTalk;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        canTalk = true;

        npcLookAt = GetComponent<NPCLookAt>();
        dialogueInteractable = GetComponent<DialogueInteractable>();
    }
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interact");
        animator.SetBool("Talk", true);
        dialogueInteractable.DoInteraction();
        // the npc cant start another conversation
        canTalk = false;
        npcLookAt.LookAtPosition(interactor.transform.position + Vector3.up*1.7f);
        return true;
    }

    public void StopInteract()
    {
       
        animator.SetBool("Talk", false);
        // the npc finnised the current conversation so it s ready for another
        canTalk =true;
        npcLookAt.LookBack();
    }

    public string GetInteractionPrompt()
    {
        return _prompt;
    }
}
