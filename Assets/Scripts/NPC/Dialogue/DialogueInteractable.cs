using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueInteractable : MonoBehaviour
{
    [SerializeField]
    UnityEvent m_OnInteraction;

    public void DoInteraction()
    {
       
        m_OnInteraction.Invoke();
    }
}