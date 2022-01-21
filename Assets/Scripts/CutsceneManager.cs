using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public bool isCutsceneOn;
    public Animator camAnim; // la camara
    public DialogueTrigger _dialogueTrigger;

    //private int text;

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
        //Destroy(gameObject); //--- quitarlo
    }
    /*
    void Dialogue(int dialogue)
    {
        text = dialogue;
    }

    void OnEnable()
    {
        GetComponent<ScriptSystem>().SelectDialogue += Dialogue;
    }

    void OnDisable()
    {
        GetComponent<ScriptSystem>().SelectDialogue -= Dialogue;
    }*/
}
