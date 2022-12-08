using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DialogueManager : MonoBehaviour
{
    [Tooltip("Link name text here.")] public Text nameText;
    [Tooltip("Link dialogue text here.")] public Text dialogueText;

    [Tooltip("Link animator here (For opening & closing dialogue).")] public Animator animator;

    [HideInInspector] public AudioSource _sfxPlayer;
    [HideInInspector] public AudioClip _typeSfx;
    [HideInInspector] public float _typeSpd;
    [HideInInspector] public float _typeVolume;
    private Queue<string> sentences;

    //Variables dependent on dialogue trigger currently used
    [HideInInspector] public bool _busy = false;
    [HideInInspector] public GameObject _dialogueTrigger;
    [HideInInspector] public bool _oneShot = false;

    private void Awake()
    {
        _sfxPlayer = GetComponent<AudioSource>();
        _sfxPlayer.mute = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        
        if (_typeSfx != null)
        {
            _sfxPlayer.clip = _typeSfx;
        }
        
        _sfxPlayer.volume = _typeVolume/100;
        _busy = true;

        //Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            EnableTrigger();
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
        StopAllCoroutines();
        TypeSfx(false);
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            
            float _typeSpdChange = (_typeSpd/10) / 100; //Converts _typespd into appropriate decimal
            dialogueText.text += letter;
            if (_typeSpd > -100 && _typeSpd < 100) //Between max & min typeSpd
            {
                if (_typeSpd > 0)
                {
                    yield return new WaitForSeconds(0.10f + (-1 * _typeSpdChange));
                }
                else if (_typeSpd < 0)
                {
                    yield return new WaitForSeconds(0.10f + (-1*_typeSpdChange));
                }
                else if (_typeSpd == 0)
                {
                    yield return new WaitForSeconds(0.10f);
                }
            }
            else if (_typeSpd == 100) //Max typespd
            {
                yield return null;
            } 
            else if (_typeSpd == -100) //Min typespd
            {
                yield return new WaitForSeconds(0.2f);
            }

        }
        TypeSfx(true);
    }

    private void TypeSfx(bool _mute)
    {
        _sfxPlayer.mute = _mute;

        if (_mute == false)
        {
            _sfxPlayer.Play();
        }

    }

    private void EndDialogue()
    {
        //Debug.Log("End of conversation...");
        animator.SetBool("isOpen", false);
        TypeSfx(true);
        _busy = false;

    }

    private void EnableTrigger()
    {
        if(_oneShot != true)
        {
            _dialogueTrigger.SetActive(true);
        }

    }

}
