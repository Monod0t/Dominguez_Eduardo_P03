using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


[CustomEditor(typeof(DialogueTrigger))]
public class DialogueEditor : Editor
{
    private float _typeSpd = 1;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        _typeSpd = EditorGUILayout.Slider("Typing Speed", _typeSpd, 1, 100);

        DialogueTrigger _dialogue = (DialogueTrigger)target;

        if (_dialogue.dialogue._textBoxStyle != null)
        {
            _dialogue.dialogue._targetImage = _dialogue.dialogue._targetTextBox.GetComponent<Image>();
            _dialogue.dialogue._targetImage.sprite = _dialogue.dialogue._textBoxStyle;
        }

        _dialogue.dialogue._targetTextBox.transform.position = _dialogue.dialogue._textBoxPos;

    }
}
