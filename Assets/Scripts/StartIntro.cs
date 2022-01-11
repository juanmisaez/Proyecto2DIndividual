using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartIntro : MonoBehaviour // CollisionCutscene
{
    public bool isCutsceneOn;
    public Animator camAnim; // la camara
    public DialogueTrigger _dialogueTrigger;

    void OnTriggerEnter2D(Collider2D collision)
    {        
        isCutsceneOn = true;
        camAnim.SetBool("cutscene1", true);
        _dialogueTrigger.TriggerDialogue();
    }

    public void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);
        Destroy(gameObject);
    }
}