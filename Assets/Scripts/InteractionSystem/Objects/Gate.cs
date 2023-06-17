using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour, IInteractable
{
    public Animator animator;

    [SerializeField]
    private string _prompt;
    [SerializeField]
    private bool isOpen;

    [SerializeField]
    private bool canInteract;


    public bool isInteractable => canInteract;
    public string InteractionPrompt => _prompt;

    public void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = true;
        canInteract = true;
    }

    public void Update()
    {
        if(isOpen)
        {
            _prompt = "Close gate";
        }
        else
        {
            _prompt = "Open gate";
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (isOpen)
        {
            Debug.Log("Closed Gate");
            animator.SetBool("isOpen", false);
            isOpen = false;
            return true;

        }
        else {
            Debug.Log("Opened Gate");
            animator.SetBool("isOpen", true);
            isOpen = true;
            return true;
        }

    }

    public void StopInteract()
    {

    }
}
