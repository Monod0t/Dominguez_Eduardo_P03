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

        

        _dialogue._dialogue.typeSpd = EditorGUILayout.Slider("Typing Speed", _dialogue._dialogue.typeSpd, -100, 100);
        _diaMan._typeSpd = _dialogue._dialogue.typeSpd;
        _diaMan._typeSfx = _dialogue._dialogue.typeSfx;

        //Checks if dialogue gameobject is chosen
        if (_dialogue._dialogue._targetTextBox != null)
        {
            //Updates Position according to custom editor
            _dialogue._dialogue._targetTextBox.transform.position = _dialogue._dialogue._textBoxPos;

            //Updates Text Box Sprite if any was chosen
            if (_dialogue._dialogue._textBoxStyle != null)
            {
                _dialogue._dialogue._targetImage = _dialogue._dialogue._targetTextBox.GetComponent<Image>();
                _dialogue._dialogue._targetImage.sprite = _dialogue._dialogue._textBoxStyle;
            }

            //Auto finds name, dialogue, & trigger gameobjects in _targetTextBox gameobject
            _dialogue._dialogue._targetName = _dialogue._dialogue._targetTextBox.transform.Find("Name").gameObject;
            _dialogue._dialogue._targetDialogue = _dialogue._dialogue._targetTextBox.transform.Find("Dialogue").gameObject;
            _dialogue._dialogue._targetTriggerBtn = _dialogue._dialogue._targetTextBox.transform.Find("DialogueTrigger").gameObject;
            _dialogue._dialogue._targetTriggerText = _dialogue._dialogue._targetTextBox.transform.Find("DialogueTrigger/Text").gameObject;


            //Updates Name Attributes & sends debug error if somehow null
            if (_dialogue._dialogue._targetName != null)
            {

                _dialogue._dialogue._targetName.transform.localPosition = _dialogue._dialogue._namePos;

                _dialogue._dialogue._nameText = _dialogue._dialogue._targetName.GetComponent<Text>();

                if (_dialogue._dialogue._nameFont != null)
                {
                    _dialogue._dialogue._nameText.font = _dialogue._dialogue._nameFont;
                }

                _dialogue._dialogue._nameText.color = _dialogue._dialogue._nameColor;
                _dialogue._dialogue._nameText.fontSize = _dialogue._dialogue._nameSize;

            }
            else
            {
                Debug.Log("Name gameobject not found!");
            }

            //Updates Dialogue Attributes & sends debug error if somehow null
            if (_dialogue._dialogue._targetDialogue != null)
            {

                _dialogue._dialogue._targetDialogue.transform.localPosition = _dialogue._dialogue._dialoguePos;
                _dialogue._dialogue._dialogueText = _dialogue._dialogue._targetDialogue.GetComponent<Text>();

                if (_dialogue._dialogue._dialogueFont != null)
                {
                    _dialogue._dialogue._dialogueText.font = _dialogue._dialogue._dialogueFont;
                }

                _dialogue._dialogue._dialogueText.color = _dialogue._dialogue._dialogueColor;
                _dialogue._dialogue._dialogueText.fontSize = _dialogue._dialogue._dialogueSize;
            }
            else
            {
                Debug.Log("Dialogue gameobject not found!");
            }

            //Updates Continue Dialogue Button
            if (_dialogue._dialogue._targetTriggerBtn != null && _dialogue._dialogue._targetTriggerText != null)
            {
                if (_dialogue._dialogue._triggerLabel != null)
                {
                    _dialogue._dialogue._triggerText.text = _dialogue._dialogue._triggerLabel;
                }

                _dialogue._dialogue._targetTriggerBtn.transform.localPosition = _dialogue._dialogue._triggerPos;
                _dialogue._dialogue._triggerText = _dialogue._dialogue._targetTriggerText.GetComponent<Text>();

                if (_dialogue._dialogue._triggerFont != null)
                {
                    _dialogue._dialogue._triggerText.font = _dialogue._dialogue._triggerFont;
                }

                _dialogue._dialogue._triggerText.color = _dialogue._dialogue._triggerColor;
                _dialogue._dialogue._triggerText.fontSize = _dialogue._dialogue._triggerSize;
            }

        }
        else if (_dialogue._dialogue._targetTextBox == null)
        {
            _dialogue._dialogue._targetName = null;
            _dialogue._dialogue._targetDialogue = null;
        }

    }
}
