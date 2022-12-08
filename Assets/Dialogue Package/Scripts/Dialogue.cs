using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [Tooltip("Provide a name for the supposed speaker.")] public string name;

    [TextArea(3, 10)]
    [Tooltip("Insert your sentences here (divide them up to fit the text box if neccessary).")] public string[] sentences;

}

