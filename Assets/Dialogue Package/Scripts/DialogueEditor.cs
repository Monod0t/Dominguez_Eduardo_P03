using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


[CustomEditor(typeof(DialogueTrigger))]
public class DialogueEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DialogueTrigger _dialogue = (DialogueTrigger)target;
        DialogueManager _diaMan = FindObjectOfType<DialogueManager>();

        _dialogue._otherOptions._triggerVolume = EditorGUILayout.Slider("Trigger Sfx Volume", _dialogue._otherOptions._triggerVolume, 0, 100);

        _dialogue._otherOptions._typeSpd = EditorGUILayout.Slider("Typing Speed", _dialogue._otherOptions._typeSpd, -100, 100);
        _dialogue._otherOptions._typeVolume = EditorGUILayout.Slider("Type Sfx Volume", _dialogue._otherOptions._typeVolume, 0, 100);
        _diaMan._typeSpd = _dialogue._otherOptions._typeSpd;
        _diaMan._typeSfx = _dialogue._otherOptions._typeSfx;

        //Checks if dialogue gameobject is chosen
        if (_dialogue._textBoxAttributes._targetTextBox != null)
        {
            //Updates Position according to custom editor
            _dialogue._textBoxAttributes._targetTextBox.transform.position = _dialogue._textBoxAttributes._textBoxPos;

            //Updates Text Box Sprite if any was chosen
            if (_dialogue._textBoxAttributes._textBoxStyle != null)
            {
                _dialogue._textBoxAttributes._targetImage = _dialogue._textBoxAttributes._targetTextBox.GetComponent<Image>();
                _dialogue._textBoxAttributes._targetImage.sprite = _dialogue._textBoxAttributes._textBoxStyle;
                _dialogue._textBoxAttributes._targetImage.color = _dialogue._textBoxAttributes._textBoxColor;
            }

            //Auto finds name, dialogue, & trigger gameobjects in _targetTextBox gameobject
            _dialogue._nameAttributes._targetName = _dialogue._textBoxAttributes._targetTextBox.transform.Find("Name").gameObject;
            _dialogue._dialogueAttributes._targetDialogue = _dialogue._textBoxAttributes._targetTextBox.transform.Find("Dialogue").gameObject;
            _dialogue._triggerAttributes._targetTriggerBtn = _dialogue._textBoxAttributes._targetTextBox.transform.Find("DialogueTrigger").gameObject;
            _dialogue._triggerAttributes._targetTriggerText = _dialogue._textBoxAttributes._targetTextBox.transform.Find("DialogueTrigger/Text").gameObject;


            //Updates Name Attributes & sends debug error if somehow null
            if (_dialogue._nameAttributes._targetName != null)
            {

                _dialogue._nameAttributes._targetName.transform.localPosition = _dialogue._nameAttributes._namePos;

                _dialogue._nameAttributes._nameText = _dialogue._nameAttributes._targetName.GetComponent<Text>();

                if (_dialogue._nameAttributes._nameFont != null)
                {
                    _dialogue._nameAttributes._nameText.font = _dialogue._nameAttributes._nameFont;
                }

                _dialogue._nameAttributes._nameText.color = _dialogue._nameAttributes._nameColor;
                _dialogue._nameAttributes._nameText.fontSize = _dialogue._nameAttributes._nameSize;

            }
            else
            {
                Debug.Log("Name gameobject not found!");
            }

            //Updates Dialogue Attributes & sends debug error if somehow null
            if (_dialogue._dialogueAttributes._targetDialogue != null)
            {

                _dialogue._dialogueAttributes._targetDialogue.transform.localPosition = _dialogue._dialogueAttributes._dialoguePos;
                _dialogue._dialogueAttributes._dialogueText = _dialogue._dialogueAttributes._targetDialogue.GetComponent<Text>();

                if (_dialogue._dialogueAttributes._dialogueFont != null)
                {
                    _dialogue._dialogueAttributes._dialogueText.font = _dialogue._dialogueAttributes._dialogueFont;
                }

                _dialogue._dialogueAttributes._dialogueText.color = _dialogue._dialogueAttributes._dialogueColor;
                _dialogue._dialogueAttributes._dialogueText.fontSize = _dialogue._dialogueAttributes._dialogueSize;
            }
            else
            {
                Debug.Log("Dialogue gameobject not found!");
            }

            //Updates Continue Dialogue Button
            if (_dialogue._triggerAttributes._targetTriggerBtn != null && _dialogue._triggerAttributes._targetTriggerText != null)
            {
                //_dialogue._triggerAtt._triggerText.text = _dialogue._triggerAtt._triggerLabel;

                _dialogue._triggerAttributes._targetTriggerBtn.transform.localPosition = _dialogue._triggerAttributes._triggerPos;
                _dialogue._triggerAttributes._triggerText = _dialogue._triggerAttributes._targetTriggerText.GetComponent<Text>();

                if (_dialogue._triggerAttributes._triggerFont != null)
                {
                    _dialogue._triggerAttributes._triggerText.font = _dialogue._triggerAttributes._triggerFont;
                }

                _dialogue._triggerAttributes._triggerText.color = _dialogue._triggerAttributes._triggerColor;
                _dialogue._triggerAttributes._triggerText.fontSize = _dialogue._triggerAttributes._triggerSize;
            }
            else
            {
                if (_dialogue._triggerAttributes._targetTriggerBtn = null)
                {
                    Debug.Log("Trigger gameobject not found!");
                }
                if (_dialogue._triggerAttributes._targetTriggerText = null)
                {
                    Debug.Log("Trigger Text not found!");
                }
            }

        }
        else if (_dialogue._textBoxAttributes._targetTextBox == null)
        {
            _dialogue._nameAttributes._targetName = null;
            _dialogue._dialogueAttributes._targetDialogue = null;
        }

    }
}
