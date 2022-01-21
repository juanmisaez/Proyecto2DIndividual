using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptSystem : MonoBehaviour
{    
    public static event Action EmptyTheBag = delegate { };
    public static event Action<int> UpdatePhase = delegate { };

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

    public void PhaseSelection(int phase)
    {
        if(phase == 0)  // Intro
        {
            Debug.Log("FASE 0, intro");
            PhaseUp();
        }
        else if(!bag) // Mochila vacía o < 3
        {
            Debug.Log("FASE 1, mochila vacía");
        }
        else if(phase == 1 && bag) // Primer pedido realizado
        {
            Debug.Log("FASE 1, primer pedido completo");
            BagEmpty();
            PhaseUp();
        }
        else if (phase == 2 && bag) // Segundo pedido realizado
        {
            Debug.Log("FASE 2, segundo pedido completo");
            BagEmpty();
            PhaseUp();
        }
        else if (phase == 3 && bag) // Tercer y último pedido realizado
        {
            Debug.Log("FASE 3, tercer pedido completo");
            BagEmpty();
        }
    }

    void PhaseUp()
    {
        phase += 1;
        UpdatePhase(phase);
    }

    void BagFull()
    {
        bag = true; // al llenarse la mochila
        //PhaseUp(); // pasa a la siguiente fase
    }

    void BagEmpty()
    {
        bag = false;
        EmptyTheBag();
    }

    void OnEnable()
    {
        InventorySystem.InventoryFull += BagFull;
        PhaseSystem.SearchPhase += PhaseSelection;
    }

    void OnDisable()
    {
        InventorySystem.InventoryFull -= BagFull;
        PhaseSystem.SearchPhase -= PhaseSelection;
    }
}