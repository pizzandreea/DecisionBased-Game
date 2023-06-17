using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{

    [SerializeField]
    private DialogueNode firstNode;

    public DialogueNode FirstNode => firstNode;
}
