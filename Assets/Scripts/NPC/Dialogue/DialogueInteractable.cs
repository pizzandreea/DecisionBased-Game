using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueInteractable : MonoBehaviour
{
    // i want to add multiple dialogues and activate them in a certain order
    // i want a int variable to keep track of the current dialogue
    [SerializeField]
    public int currentDialogue;


    
    [SerializeField]
    UnityEvent m_OnInteraction;

    [SerializeField]
    UnityEvent m_OnInteraction2;

    void start()
    {
        currentDialogue = 0;
    }

    public void DoInteraction()
    {
        if(currentDialogue == 0)
        {
            m_OnInteraction.Invoke();
            
        }
        else if(currentDialogue == 1)
        {
            m_OnInteraction2.Invoke();
            Debug.Log("second dialogue");
            
        }
        else
        {
            Debug.Log("No more dialogues");
        }
        
    }

    public void GoToNextDialogue()
    {
        currentDialogue++;
        m_OnInteraction = m_OnInteraction2;
    }
}