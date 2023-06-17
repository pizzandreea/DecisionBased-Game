using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Narration Line")]
public class NarrationLine : ScriptableObject
{
    [SerializeField]
    private NarrationCharacter character;
    [SerializeField]
    private string text;

    public NarrationCharacter Character => character;

    public string Text => text;


}
