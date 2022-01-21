using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhaseSystem : MonoBehaviour
{
    public static event Action<int> SearchPhase = delegate { };

    [SerializeField]
    private int currentPhase;

    public void PhaseUpdate(int phase) // le llega la fase del trigger por CollisionCutscene
    {
        // No tiene que actualizar a lo que detecta
        // tiene que comparar con la fase en la que está
        // la fase la decide el ScriptSystem
        if(currentPhase == phase)
        {
            SearchPhase(GetPhase());
        }        
    }

    void NewPhase(int phase)
    {
        currentPhase = phase;
        SearchPhase(GetPhase());
    }

    public int GetPhase()
    {
        return currentPhase;
    }

    public void OnEnable()
    {
        ScriptSystem.UpdatePhase += NewPhase;
    }

    void OnDisable()
    {
        ScriptSystem.UpdatePhase -= NewPhase;
    }
}