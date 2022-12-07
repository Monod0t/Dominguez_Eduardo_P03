using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue _dialogue;
    private DialogueManager _dialogueManager;

    private void Awake()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
        _dialogueManager.StartDialogue(_dialogue);

        UpdateTextBox();

        if (_dialogue._oneShot)
        {
            this.gameObject.SetActive(false);
        }

    }

    void UpdateTextBox()
    {
        //Updates Text Box sprite & color with info from dialogue trigger
        _dialogue._targetImage.sprite = _dialogue._textBoxStyle;
        _dialogue._targetImage.color = _dialogue._textBoxColor;

        //Updates name local pos., font, color, & size with info from dialogue trigger
        _dialogue._targetName.transform.localPosition = _dialogue._namePos;
        _dialogue._nameText.font = _dialogue._nameFont;
        _dialogue._nameText.color = _dialogue._nameColor;
        _dialogue._nameText.fontSize = _dialogue._nameSize;

        //Updates dialogue local pos., font, color, & size with info from dialogue trigger
        _dialogue._targetDialogue.transform.localPosition = _dialogue._dialoguePos;
        _dialogue._dialogueText.font = _dialogue._dialogueFont;
        _dialogue._dialogueText.color = _dialogue._dialogueColor;
        _dialogue._dialogueText.fontSize = _dialogue._dialogueSize;

        //Updates trigger local pos., font, color, & size with info from dialogue trigger
        _dialogue._targetTriggerBtn.transform.localPosition = _dialogue._triggerPos;
        _dialogue._triggerText.font = _dialogue._triggerFont;
        _dialogue._triggerText.color = _dialogue._triggerColor;
        _dialogue._triggerText.fontSize = _dialogue._triggerSize;

    }

}
