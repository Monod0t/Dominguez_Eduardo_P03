using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NameAttributes
{
    [Header("Name Text Attributes")]
    [Tooltip("Should be auto found if gameobject's name is 'Name'.")] public GameObject _targetName;
    [Tooltip("Set the local position relative to text box.")] public Vector2 _namePos = new Vector2(0, 150);
    [HideInInspector] public Text _nameText;
    [Tooltip("Sets the font style.")] public Font _nameFont;
    [Tooltip("Sets the text color.")] public Color _nameColor = new Color(255, 255, 255, 255);
    [Tooltip("Sets the font size.")] public int _nameSize = 60;

}
