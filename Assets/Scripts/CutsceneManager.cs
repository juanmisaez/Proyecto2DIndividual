using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CutsceneManager : MonoBehaviour //CutsceneSystem
{
    public static event Action<bool> InCutscene = delegate { };
    public static event Action WinGame = delegate { }; // Al WinMenu

    public bool isCutsceneOn;
    bool win;
    public Animator camAnim; // la camara
    public DialogueTrigger _dialogueTrigger;

    void Dialogue(int dialogue)
    {
        isCutsceneOn = true;
        InCutscene(isCutsceneOn);
        camAnim.SetBool("cutscene1", true);
        _dialogueTrigger.TriggerDialogue(dialogue);

        if(dialogue == 4)
        {
            win = true;
        }
    }

    public void StopCutscene()
    {
        isCutsceneOn = false;
        InCutscene(isCutsceneOn);
        camAnim.SetBool("cutscene1", false);

        if(win == true)
        {
            WinGame(); // activar menú de victoria
        }
        
    }

    void OnEnable()
    {
        GetComponent<ScriptSystem>().SelectDialogue += Dialogue;
    }

    void OnDisable()
    {
        GetComponent<ScriptSystem>().SelectDialogue -= Dialogue;
    }
}