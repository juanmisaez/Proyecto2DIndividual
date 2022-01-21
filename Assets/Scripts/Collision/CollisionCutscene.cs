using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCutscene : CollisionSystem
{    
    [SerializeField]
    private int phase; // si la tiene el padre, no haría falta

    protected override void OnCollision(Collider2D other)
    {
        GetComponent<ScriptManager>().PhaseSelection(phase);
    }
    //------------------------------------------------------------






    // ********************************** OTRO SCRIPT DIFERENTE **********************************


    



    public bool isCutsceneOn;
    public Animator camAnim; // la camara
    //public DialogueTrigger _dialogueTrigger; //---- Cambiar por una lista
    public DialogueTrigger[] _dialogue; // Scripts con los textos

    private int text;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        isCutsceneOn = true;
        camAnim.SetBool("cutscene1", true);
        //_dialogueTrigger.TriggerDialogue();
        _dialogue[text].TriggerDialogue();
    }

    public void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);
        Destroy(gameObject); //--- quitarlo // Que lo gestione el ScriptManager
    }

    void Dialogue(int dialogue)
    {
        text = dialogue;
        //return text;
    }

    //------------------------------------------------------------
   
    void OnEnable()
    {
        GetComponent<ScriptManager>().SelectDialogue += Dialogue;
    }

    void OnDisable()
    {
        GetComponent<ScriptManager>().SelectDialogue -= Dialogue;
    }
}