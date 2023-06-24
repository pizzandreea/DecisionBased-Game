using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// vom avea 2 tipuri de noduri (Simple si choice)
public abstract class DialogueNode : ScriptableObject
{
    [SerializeField]
    private NarrationLine narrationLine;

    public NarrationLine NarrationLine => narrationLine;

    public bool isFinal = false;
    public string ending = "";

    public abstract bool CanBeFollowedByNode(DialogueNode node);

    public abstract void Accept(DialogueNodeVisitor visitor);

    
}
