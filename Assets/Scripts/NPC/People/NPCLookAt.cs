using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NPCLookAt : MonoBehaviour
{
    [SerializeField]
    private Rig rig;
    [SerializeField]
    private Transform npcLookAtTransform;

    [SerializeField]
    private Transform initialTarget;

    private bool isLookingAtPosition;

    private void Start()
    {
        initialTarget = npcLookAtTransform;
    }

    private void Update()
    {
        float targetWeight = isLookingAtPosition ? 1.0f : 0.0f;

        float lerpSpeed = 2f;
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * lerpSpeed);  
    }

    public void LookAtPosition(Vector3 lookAtPosition)
    {
        isLookingAtPosition = true;
        npcLookAtTransform.position = lookAtPosition;
   
    }

    public void LookBack()
    {
        isLookingAtPosition = false;
        npcLookAtTransform = initialTarget;
    }


}
