using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> frases;

    void Start()
    {
        frases = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.nombre;
        frases.Clear();

        foreach(string frase in dialogue.frases)
        {
            frases.Enqueue(frase);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(frases.Count == 0)
        {
            EndDialogue();
            return;
        }

        string frase = frases.Dequeue();
        dialogueText.text = frase;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        FindObjectOfType<CollisionStartIntro>()?.StopCutscene();
        FindObjectOfType<CollisionCutscene>()?.StopCutscene();
    }
}