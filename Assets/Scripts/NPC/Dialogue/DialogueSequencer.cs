using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueException : System.Exception
{
    public DialogueException(string message) 
        : base(message) { }
}

public class DialogueSequencer : MonoBehaviour
{
    public Interactor interactor;
    public delegate void DialogueCallBack(Dialogue dialogue);
    public delegate void DialogueNodeCallBack(DialogueNode node);

    public DialogueCallBack OnDialogueStart;
    public DialogueCallBack OnDialogueEnd;
    public DialogueNodeCallBack OnDialogueNodeStart;
    public DialogueNodeCallBack OnDialogueNodeEnd;

    private Dialogue currentDialogue;
    private DialogueNode currentNode;   

    public void Start()
    {
        //find the object with the name Player
        interactor = GameObject.Find("Player").GetComponent<Interactor>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if(currentDialogue == null)
        {
            currentDialogue = dialogue;
            OnDialogueStart?.Invoke(currentDialogue);
            StartDialogueNode(dialogue.FirstNode);
        }

        else
        {
            throw new DialogueException("Can't start a dialogue when another one is running");
        }
    }


    public void EndDialogue(Dialogue dialogue)
    {
        if(currentDialogue == dialogue)
        {
            StopDialogueNode(currentNode);
            OnDialogueEnd?.Invoke(currentDialogue);
            currentDialogue = null;
        }
        else
        {
            throw new DialogueException("Trying to end a dialogue that is not running");
        }
    }

    private bool CanStartNode(DialogueNode node)
    {
        return (currentNode == null || node == null || currentNode.CanBeFollowedByNode(node));
    }

    public void StartDialogueNode(DialogueNode node)
    {
        if (CanStartNode(node))
        {
            StopDialogueNode(currentNode);
            
            currentNode = node; 
            
            if (currentNode != null)
            {
                
                if(currentNode.ending != "")
                {
                    Debug.Log(currentNode.ending + currentNode.NarrationLine.CharacterName);
                    // i want to send a message to the interactor object to activate a function of the name of the message
                    //interactor.SendMessage(currentNode.ending, currentNode.NarrationLine.CharacterName);
                }
                
                OnDialogueNodeStart?.Invoke(currentNode);
            }
            else
            {
                EndDialogue(currentDialogue);
            }
        }
        else
        {
            throw new DialogueException("Failed to start dialogue node");
        }
    }

    private void StopDialogueNode(DialogueNode node)
    {
        if(currentNode == node)
        {
            OnDialogueNodeEnd?.Invoke(currentNode);
            currentNode = null;

        }
        else
        {
            throw new DialogueException("Trying to end dialogue node that is not running");
        }
    }

  
}

