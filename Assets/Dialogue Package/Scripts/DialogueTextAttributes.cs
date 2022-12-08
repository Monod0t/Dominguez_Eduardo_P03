using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueTextAttributes
{
    [Header("Dialogue Text Attributes")]
    [Tooltip("Should be auto found if gameobject's name is 'Dialogue'.")] public GameObject _targetDialogue;
    [Tooltip("Set the local position relative to text box")] public Vector2 _dialoguePos = new Vector2(0, -25);
    [HideInInspector] public Text _dialogueText;
    [Tooltip("Sets the font style.")] public Font _dialogueFont;
    [Tooltip("Sets the text color.")] public Color _dialogueColor = new Color(0, 0, 0, 255);
    [Tooltip("Sets the font size.")] public int _dialogueSize = 50;

}
