using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptManager : MonoBehaviour
{
    /*
    public DialogueTrigger[] _dialogue; // Scripts con los textos
    public CollisionCutscene[] _trigger; // triggers

    public bool isCutsceneOn;
    public Animator camAnim; // la camara
    */

    public event Action<int> SelectDialogue = delegate { };

    private bool bag;
    private int phase;
       

    /*
    public class CollisionCutscene : CollisionSystem
{
    public bool isCutsceneOn;
    public Animator camAnim; // la camara
    public DialogueTrigger _dialogueTrigger;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        isCutsceneOn = true;
        camAnim.SetBool("cutscene1", true);
        _dialogueTrigger.TriggerDialogue();        
    }

    public void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);
        Destroy(gameObject); //--- Que lo gestione el ScriptManager
    }
}
    */

    /*
    // ------------ Este script NO gestiona OnTriggerEnter2D ---------------------
    void OnTriggerEnter2D()//Collider2D other)
    {
        isCutsceneOn = true;
        camAnim.SetBool("cutscene1", true);
        /*other.gameObject.GetComponent<DialogueTrigger>()?.TriggerDialogue();
                                                _dialogue[1]?.TriggerDialogue();
    }
    //----------------------------------------------------------------------
    
    /*
     "filtros:"
    - mochila vacía  !bag
    - fase 1         phase == 1
    - fase 2         phase == 2
    - fase 3         phase == 3
     */

    public void PhaseSelection(int _phase)
    {
        if(phase == 0)  // Intro
        {
            SelectDialogue(0);
        }
        else if(!bag)   // Mochila vacía, < 3
        {
            SelectDialogue(1);
        }
        else if(phase == 1 && bag) // Primer pedido realizado
        {
            BagEmpty();
            SelectDialogue(2);
        }
        else if (phase == 2 && bag) // Segundo pedido realizado
        {
            BagEmpty();
            SelectDialogue(3);
        }
        else if (phase == 3 && bag)// Tercer y último pedido realizado
        {
            BagEmpty();
            SelectDialogue(4);
        }
    }

    void PhaseUp()
    {
        phase += 1;
    }

    void BagFull()
    {
        bag = true; // al llenarse la mochila
        PhaseUp(); // pasa a la siguiente fase
    }

    void BagEmpty()
    {
        bag = false;
    }

    void OnEnable()
    {
        InventorySystem.InventoryFull += BagFull;
        //GetComponent<CollisionCutscene>().Selection += PhaseSelection; // Otro script, NEW CollisionCutscene : MonoBehaviour
    }

    void OnDisable()
    {
        InventorySystem.InventoryFull -= BagFull;
        //GetComponent<CollisionCutscene>().Selection -= PhaseSelection; // Otro script, NEW CollisionCutscene : MonoBehaviour
    }
}