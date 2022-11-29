using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

    [Header("TextBox Attributes")]
    public GameObject _targetTextBox = null;
    [HideInInspector] public Image _targetImage = null;
    public Sprite _textBoxStyle = null;
    public Vector2 _textBoxPos = new Vector2(0, 0);
    public Color _textBoxColor = new Color(255, 255, 255);

    public AudioClip typeSfx;



}

