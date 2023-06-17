using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Narration Character")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField]
    private string characterName;

    public string CharacterName => characterName;
}
