using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    [HideInInspector] public AudioClip _typeSfx;
    public float _typeSpd;
    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

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
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
        StopAllCoroutines();
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
    }

    public void TypeSfx()
    {

    }

    private void EndDialogue()
    {
        //Debug.Log("End of conversation...");
        animator.SetBool("isOpen", false);

    }


}
