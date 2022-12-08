using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue _dialogue;
    public TextBoxAttributes _textBoxAttributes;
    public NameAttributes _nameAttributes;
    public DialogueTextAttributes _dialogueAttributes;
    public TriggerAttributes _triggerAttributes;
    public OtherAttributes _otherOptions;
    private DialogueManager _dialogueManager;

    private void Awake()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        //Will not activate sequence if another dialogue is being played
        if (_dialogueManager._busy)
            return;

        if (_otherOptions._triggerSfx != null)
        {
            PlayTriggerSfx();
        }

        UpdateTextBox();

        _dialogueManager._dialogueTrigger = this.gameObject;
        _dialogueManager._oneShot = _otherOptions._oneShot;
        _dialogueManager.StartDialogue(_dialogue);

        this.gameObject.SetActive(false);

    }

    private void PlayTriggerSfx()
    {
        AudioSource audioSource = AudioHelper.PlayClip2D(_otherOptions._triggerSfx, _otherOptions._triggerVolume/100);
        //audioSource.pitch = UnityEngine.Random.Range(0.5f, 1);
    }

    void UpdateTextBox()
    {
        //Updates Text Box sprite & color with info from dialogue trigger
        _textBoxAttributes._targetImage.sprite = _textBoxAttributes._textBoxStyle;
        _textBoxAttributes._targetImage.color = _textBoxAttributes._textBoxColor;

        //Updates name local pos., font, color, & size with info from dialogue trigger
        _nameAttributes._targetName.transform.localPosition = _nameAttributes._namePos;
        _nameAttributes._nameText.font = _nameAttributes._nameFont;
        _nameAttributes._nameText.color = _nameAttributes._nameColor;
        _nameAttributes._nameText.fontSize = _nameAttributes._nameSize;

        //Updates dialogue local pos., font, color, & size with info from dialogue trigger
        _dialogueAttributes._targetDialogue.transform.localPosition = _dialogueAttributes._dialoguePos;
        _dialogueAttributes._dialogueText.font = _dialogueAttributes._dialogueFont;
        _dialogueAttributes._dialogueText.color = _dialogueAttributes._dialogueColor;
        _dialogueAttributes._dialogueText.fontSize = _dialogueAttributes._dialogueSize;

        //Updates trigger local pos., font, color, & size with info from dialogue trigger
        _triggerAttributes._targetTriggerBtn.transform.localPosition = _triggerAttributes._triggerPos;
        _triggerAttributes._triggerText.font = _triggerAttributes._triggerFont;
        _triggerAttributes._triggerText.color = _triggerAttributes._triggerColor;
        _triggerAttributes._triggerText.fontSize = _triggerAttributes._triggerSize;

        //Updates typing sfx & speed
        if (_otherOptions._typeSfx != null)
        {
            _dialogueManager._typeSfx = _otherOptions._typeSfx;
            _dialogueManager._typeVolume = _otherOptions._typeVolume;
        }
        _dialogueManager._typeSpd = _otherOptions._typeSpd;
        
        //Updates sfx


    }

}
