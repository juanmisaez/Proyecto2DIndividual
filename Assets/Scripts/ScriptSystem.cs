using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptSystem : MonoBehaviour
{    
    public static event Action EmptyTheBag = delegate { }; // Al InventorSystem
    public static event Action<int> UpdatePhase = delegate { }; // Al CollisionCutscene
    public event Action<int> SelectDialogue = delegate { }; // Al CutsceneManager

    private bool bag;
    private int phase;
    private int beforePhase;

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
        if(phase == 0) // Intro
        {
            Debug.Log("FASE 0, intro");
            SelectDialogue(phase);
            NextPhase();
        }
        else if(!bag) // Mochila no llena del todo
        {
            Debug.Log("FASE 1, mochila vacía");
            SelectDialogue(phase);
        }
        else if(phase == 2 && bag) // Primer pedido realizado
        {
            Debug.Log("FASE 2, primer pedido completo");
            SelectDialogue(phase);
            BagEmpty();
            SavePhase(phase);
            ReturnPhase();
            //**desbloquear el romper bloques azules**
        }
        else if (phase == 3 && bag) // Segundo pedido realizado
        {
            Debug.Log("FASE 3, segundo pedido completo");
            SelectDialogue(phase);
            BagEmpty();
            SavePhase(phase);
            ReturnPhase();
            //**desbloquear el romper bloques metálicos**
        }
        else if (phase == 4 && bag) // Tercer y último pedido realizado
        {
            Debug.Log("FASE 4, tercer pedido completo");
            SelectDialogue(phase);
            BagEmpty();
        }
    }

    void NextPhase()
    {
        //phase += 1;
        phase += beforePhase;
        UpdatePhase(phase);
    }

    void SavePhase(int currentPhase)
    {
        beforePhase = currentPhase;
        Debug.Log("la fase anterior es " + beforePhase); //---
    }

    void ReturnPhase()
    {
        phase = 1; // fase de la mochila vacía
        UpdatePhase(phase);
    }

    void BagFull()
    {
        bag = true; // al llenarse la mochila
        NextPhase();
    }

    void BagEmpty()
    {
        bag = false;
        EmptyTheBag();
    }

    void OnEnable()
    {
        beforePhase = 1;

        InventorySystem.InventoryFull += BagFull;
        PhaseSystem.SearchPhase += PhaseSelection;
    }

    void OnDisable()
    {
        InventorySystem.InventoryFull -= BagFull;
        PhaseSystem.SearchPhase -= PhaseSelection;
    }
}