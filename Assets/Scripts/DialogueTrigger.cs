using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //public Dialogue[] dialogue;

    public void TriggerDialogue()
    //public void TriggerDialogue(int phase)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue[phase]);
    }
    /*
    public void OnEnable()
    {
        PhaseSystem.SearchPhase += TriggerDialogue;
    }

    void OnDisable()
    {
        PhaseSystem.SearchPhase -= TriggerDialogue;
    }*/
}