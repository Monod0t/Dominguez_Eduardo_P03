using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextBoxAttributes
{
    [Header("Text Box Attributes")]
    [Tooltip("Once selected, Name, Dialogue, & Trigger should be auto found if gameobject names are correct")] public GameObject _targetTextBox = null;
    [HideInInspector] public Image _targetImage = null;
    [Tooltip("Set the world position of the text box (Position will be changed by animator, if any).")] public Vector2 _textBoxPos = new Vector2(960, 270);
    [Tooltip("Set the sprite used for the text box image.")] public Sprite _textBoxStyle = null;
    [Tooltip("Change the color of the text box")] public Color _textBoxColor = new Color(255, 255, 255, 255);

}
