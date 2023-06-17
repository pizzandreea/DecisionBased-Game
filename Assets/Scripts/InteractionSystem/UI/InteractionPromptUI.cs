using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField]
    private GameObject _imagePanel;
    [SerializeField]
    private TextMeshProUGUI _promptMessage;
    public bool isShowing = false; 


    private void Start()
    {
        _mainCamera = Camera.main;
        _imagePanel.SetActive(false);

    }

    private void LateUpdate()
    {
        var rotation = _mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public void SetUp(string promptText)
    {
        _promptMessage.text = promptText;
        _imagePanel.SetActive(true);
        isShowing = true; 
    }

    public void Close()
    {
        isShowing = false;
        _imagePanel.SetActive(false);
    }
}
