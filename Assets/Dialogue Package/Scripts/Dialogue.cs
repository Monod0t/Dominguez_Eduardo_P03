using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[System.Serializable]
public class Dialogue
{

    [Header("One-time Trigger?")]
    public bool _oneShot;

    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

    [Header("Text Box Attributes")]
    public GameObject _targetTextBox = null;
    [HideInInspector] public Image _targetImage = null;
    public Vector2 _textBoxPos = new Vector2(960, 270);
    public Sprite _textBoxStyle = null;
    public Color _textBoxColor = new Color(255, 255, 255, 255);

    [Header("Name Text Attributes")]
    public GameObject _targetName;
    public Vector2 _namePos = new Vector2(655, 420);
    [HideInInspector] public Text _nameText;
    public Font _nameFont;
    public Color _nameColor = new Color(255, 255, 255, 255);
    public int _nameSize = 60;

    [Header("Dialogue Text Attributes")]
    public GameObject _targetDialogue;
    public Vector2 _dialoguePos = new Vector2(960, 225);
    [HideInInspector] public Text _dialogueText;
    public Font _dialogueFont;
    public Color _dialogueColor = new Color(255, 255, 255, 255);
    public int _dialogueSize = 50;

    [Header("Continue Dialouge Trigger")]
    public GameObject _targetTriggerBtn;
    public string _triggerLabel = "Continue";
    public Vector2 _triggerPos = new Vector2(960, 150);
    [HideInInspector] public GameObject _targetTriggerText;
    [HideInInspector] public Text _triggerText;
    public Font _triggerFont;
    public Color _triggerColor = new Color(255, 255, 255, 255);
    public int _triggerSize = 40;

    [Header("Other")]
    public AudioClip typeSfx;
    [HideInInspector] public float typeSpd = 50;



}

