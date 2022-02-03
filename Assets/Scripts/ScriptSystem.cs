using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptSystem : MonoBehaviour
{    
    public static event Action EmptyTheBag = delegate { }; // Al InventorSystem
    public static event Action<int> UpdatePhase = delegate { }; // Al CollisionCutscene
    public event Action<int> SelectDialogue = delegate { }; // Al CutsceneManager

    public static event Action<int> UpgradePickaxe = delegate { }; // Al BreakBlockSystem

    private bool bag;
    private int phase;
    private int beforePhase;

    public void PhaseSelection(int phase)
    {
        if(phase == 0) // Intro
        {
            SelectDialogue(phase);
            NextPhase();
        }
        else if(!bag) // Mochila no llena del todo
        {
            SelectDialogue(phase);
        }
        else if(phase == 2 && bag) // Primer pedido realizado
        {
            SelectDialogue(phase);
            BagEmpty();
            SavePhase(phase);
            ReturnPhase();
            UpgradePickaxe(phase); // desbloquear el romper bloques azules
        }
        else if (phase == 3 && bag) // Segundo pedido realizado
        {
            SelectDialogue(phase);
            BagEmpty();
            SavePhase(phase);
            ReturnPhase();
            UpgradePickaxe(phase); // desbloquear el romper bloques metálicos
        }
        else if (phase == 4 && bag) // Tercer y último pedido realizado
        {
            SelectDialogue(phase);
            BagEmpty();
        }
    }

    void NextPhase()
    {
        phase += beforePhase;
        UpdatePhase(phase);
    }

    void SavePhase(int currentPhase)
    {
        beforePhase = currentPhase;
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