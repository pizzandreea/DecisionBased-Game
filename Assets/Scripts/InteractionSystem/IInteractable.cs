using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public string InteractionPrompt { get; }
    public bool Interact(Interactor interactor);

<<<<<<< HEAD
    public void StopInteract();

=======
>>>>>>> eaa0af3 (Choose-your-Adventure)
    public bool isInteractable { get; }

}
