using System.Collections;
using System.Collections.Generic;
using TMPro;
<<<<<<< HEAD

using UnityEngine;

public class Interactor : MonoBehaviour, IDataPersistence
{
    // the point which detects interactable objects
    [SerializeField]
    public Transform _interactionPoint;
=======
using UnityEditor.UIElements;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // the point which detects interactable objects
    [SerializeField]
    private Transform _interactionPoint;
>>>>>>> eaa0af3 (Choose-your-Adventure)
    [SerializeField]
    private float _interactionPointRadius = 0.5f;
    // the type of layer mask the objects are on
    [SerializeField]
    private LayerMask _interactableMask;
<<<<<<< HEAD
    [SerializeField]
    private LayerMask _interactableMaskNPC;
=======
>>>>>>> eaa0af3 (Choose-your-Adventure)

    // the colliders we detect at a time
    private readonly Collider[] colliders = new Collider[3];

<<<<<<< HEAD
    // the colliders we detect at a time
    private readonly Collider[] collidersNPC = new Collider[3];

=======
>>>>>>> eaa0af3 (Choose-your-Adventure)
    [SerializeField]
    private InteractionPromptUI _interactionPromptUI;

    //the number of colliders we detect
    [SerializeField]
    private int _numCollFound;

<<<<<<< HEAD

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
        
=======
    private IInteractable _interactable;


    private void Update()
    {
>>>>>>> eaa0af3 (Choose-your-Adventure)
        _numCollFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, colliders, _interactableMask);
        if (_numCollFound > 0)
        {
            //we try to interact with the first detected element
<<<<<<< HEAD
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
=======
            _interactable = colliders[0].GetComponent<IInteractable>();

            if(_interactable != null && _interactable.isInteractable)
            {
                //if we can interact with something
                if(!_interactionPromptUI.isDisplayed)
                {
                    //if nothing is displayed
                    _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _interactable.Interact(this);
                    if(!_interactable.isInteractable)
>>>>>>> eaa0af3 (Choose-your-Adventure)
                    {
                        _interactionPromptUI.Close();
                    }
                }
            }
            
        }
        else
        {
<<<<<<< HEAD

            if(lastInteractable != null)
            {
                lastInteractable.StopInteract();
            }
            if (_interactionPromptUI.isShowing)
=======
            if (_interactable != null)
            {
                _interactable = null;
            }
            if (_interactionPromptUI.isDisplayed)
>>>>>>> eaa0af3 (Choose-your-Adventure)
            {
                _interactionPromptUI.Close();
            }
        }
<<<<<<< HEAD


=======
>>>>>>> eaa0af3 (Choose-your-Adventure)
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
