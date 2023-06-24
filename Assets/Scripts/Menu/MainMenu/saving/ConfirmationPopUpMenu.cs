using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ConfirmationPopUpMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;
    [SerializeField]
    private TextMeshProUGUI messageText;

    public void ActivateMenu(string displayText, UnityAction yesAction, UnityAction noAction)
    {
        this.gameObject.SetActive(true);
        //set the display text
        messageText.text = displayText;
        // remove any existing listeners
        // removes listeners added through code
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        // assign the onClick listeners
        yesButton.onClick.AddListener(() => {
            DeactivateMenu();
            yesAction();
        });
        noButton.onClick.AddListener(() => {
            DeactivateMenu();
            noAction();
        });
    }

    private void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

}
