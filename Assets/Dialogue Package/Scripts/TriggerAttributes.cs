using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TriggerAttributes
{
    [Header("Continue Dialogue Trigger")]
    [Tooltip("Should be auto found if gameobject's name is 'DialogueTrigger'.")] public GameObject _targetTriggerBtn;
    //public string _triggerLabel = "Continue";
    [Tooltip("Set the local position of the trigger relative to text box")] public Vector2 _triggerPos = new Vector2(560, -125);
    [HideInInspector] public GameObject _targetTriggerText;
    [HideInInspector] public Text _triggerText;
    [Tooltip("Sets the font style.")] public Font _triggerFont;
    [Tooltip("Sets the text color.")] public Color _triggerColor = new Color(255, 255, 255, 255);
    [Tooltip("Sets the font size.")] public int _triggerSize = 40;

}
