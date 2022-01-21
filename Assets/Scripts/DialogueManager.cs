using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string frase in dialogue.sentences)
        {
            sentences.Enqueue(frase);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        FindObjectOfType<CollisionCutscene>()?.StopCutscene();
        FindObjectOfType<CollisionCapataz>()?.StopCutscene(); //--No hará falta
        FindObjectOfType<CollisionCapatazProgression>()?.StopCutscene(); //--No hará falta
    }
}