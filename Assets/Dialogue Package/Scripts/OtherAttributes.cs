using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OtherAttributes
{
    [Tooltip("Should the dialogue trigger only be activated once.")] public bool _oneShot;

    [Tooltip("Sets the sfx used when dialogue trigger is activated.")] public AudioClip _triggerSfx;
    [Tooltip("Sets the sfx used while the sentences are typed, if any.")] public AudioClip _typeSfx;
    [HideInInspector] public float _triggerVolume = 100;
    [HideInInspector] public float _typeSpd = 50;
    [HideInInspector] public float _typeVolume = 100;

}
