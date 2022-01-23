using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour //CutsceneSystem
{
    public bool isCutsceneOn;
    public Animator camAnim; // la camara
    public DialogueTrigger _dialogueTrigger;

    //private int text;

    void Dialogue(int dialogue)
    {
        //text = dialogue;

        isCutsceneOn = true;
        camAnim.SetBool("cutscene1", true);
        _dialogueTrigger.TriggerDialogue(dialogue);
    }
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        isCutsceneOn = true;
        camAnim.SetBool("cutscene1", true);
        _dialogueTrigger.TriggerDialogue(GetText());
    }*/

    public void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);

        /*if(text == 0)
        {
            Destroy(gameObject);
        }*/
    }

    /*
    void Dialogue(int dialogue)
    {
        text = dialogue;
    }
    
    public int GetText()
    {
        return text;
    }*/

    void OnEnable()
    {
        GetComponent<ScriptSystem>().SelectDialogue += Dialogue;
    }

    void OnDisable()
    {
        GetComponent<ScriptSystem>().SelectDialogue -= Dialogue;
    }
}