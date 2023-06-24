using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class Interactor : MonoBehaviour, IDataPersistence
{
    // the point which detects interactable objects
    [SerializeField]
    public Transform _interactionPoint;
    [SerializeField]
    private float _interactionPointRadius = 0.5f;
    // the type of layer mask the objects are on
    [SerializeField]
    private LayerMask _interactableMask;
    [SerializeField]
    private LayerMask _interactableMaskNPC;

    // the colliders we detect at a time
    private readonly Collider[] colliders = new Collider[3];

    // the colliders we detect at a time
    private readonly Collider[] collidersNPC = new Collider[3];

    [SerializeField]
    private InteractionPromptUI _interactionPromptUI;

    //the number of colliders we detect
    [SerializeField]
    private int _numCollFound;


    private IInteractable _currentInteractableObject;
    private IInteractable lastInteractable = null;

    public bool foundMom = false;
    public bool hasIngredients = false;
    
    public int relationshipBob = 0;
    public int relationshipJohn = 0;
    

    public void growRelationship(string characterName)
    {
        if(characterName == "John")
        {
            relationshipJohn++;
        }
        else if(characterName == "Bob")
        {
            relationshipBob++;
        }
    }

    public void lowerRelationship(string characterName)
    {
        if (characterName == "John")
        {
            relationshipJohn--;
        }
        else if (characterName == "Bob")
        {
            relationshipBob--;
        }
    }


    public void LoadData(GameData gameData)
    {
        
        //this.transform.position = gameData.playerPosition;
    }

    public void SaveData( GameData gameData)
    {
        
        gameData.playerPosition = this.transform.position;
        gameData.currentDateTime = System.DateTime.Now.ToString();
    }

    private void Start()
    {
         _interactionPoint = GetComponent<Transform>();
    }
    private void Update()
    {
        
        _numCollFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, colliders, _interactableMask);
        if (_numCollFound > 0)
        {
            //we try to interact with the first detected element
            _currentInteractableObject = colliders[0].GetComponent<IInteractable>();

            if(_currentInteractableObject != null && _currentInteractableObject.isInteractable)
            {
                //if we can interact with something
                if(!_interactionPromptUI.isShowing)
                {
                    //if nothing is displayed
                    _interactionPromptUI.SetUp(_currentInteractableObject.InteractionPrompt);
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    lastInteractable = _currentInteractableObject;
                    Debug.Log("pressed f");
                    _currentInteractableObject.Interact(this);
                    if(!_currentInteractableObject.isInteractable)
                    {
                        _interactionPromptUI.Close();
                    }
                }
            }
            
        }
        else
        {

            if(lastInteractable != null)
            {
                lastInteractable.StopInteract();
            }
            if (_interactionPromptUI.isShowing)
            {
                _interactionPromptUI.Close();
            }
        }


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
