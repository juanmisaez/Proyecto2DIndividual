using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    public void TriggerDialogue(int phase)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[phase]);
    }    
}