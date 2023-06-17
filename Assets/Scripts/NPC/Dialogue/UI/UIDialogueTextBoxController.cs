using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIDialogueTextBoxController : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField]
    private TextMeshProUGUI speakerText;
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [SerializeField]
    private RectTransform choicesBoxTransform;
    [SerializeField]
    private UIDialogueChoiceController choiceControllerPrefab;

    [SerializeField]
    private DialogueChannel dialogueChannel;

    private bool listenToInput = false;
    private DialogueNode nextNode = null;

    private void Awake()
    {
        dialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        dialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;

        gameObject.SetActive(false);
        choicesBoxTransform.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        dialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        dialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }


    // daca apas F incearca sa porneasca alta conv
    private void Update()
    {
        if (listenToInput && Input.GetKeyDown(KeyCode.G))
        {
            dialogueChannel.RaiseRequestDialogueNode(nextNode);
        }
    }

    private void OnDialogueNodeStart(DialogueNode node)
    {
        gameObject.SetActive(true);

        dialogueText.text = node.NarrationLine.Text;
        speakerText.text = node.NarrationLine.Character.CharacterName;

        node.Accept(this);
    }

    private void OnDialogueNodeEnd(DialogueNode node)
    {
        nextNode = null;
        listenToInput = false;
        dialogueText.text = "";
        speakerText.text = "";

        foreach (Transform child in choicesBoxTransform)
        {
            Destroy(child.gameObject);
        }

        gameObject.SetActive(false);
        choicesBoxTransform.gameObject.SetActive(false);
    }

    public void Visit(BasicDialogueNode node)
    {
        listenToInput = true;
        nextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        choicesBoxTransform.gameObject.SetActive(true);

        foreach (DialogueChoice choice in node.Choices)
        {
            UIDialogueChoiceController newChoice = Instantiate(choiceControllerPrefab, choicesBoxTransform);
            newChoice.Choice = choice;
        }
    }
}
