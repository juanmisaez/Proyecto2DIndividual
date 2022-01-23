using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhaseSystem : MonoBehaviour
{
    public static event Action<int> SearchPhase = delegate { }; // Al Scriptsystem

    [SerializeField]
    private int currentPhase;

    public void PhaseUpdate(int phase) // le llega la fase del trigger por CollisionCutscene
    {
        currentPhase = phase;

        SearchPhase(GetPhase());
    }

    void CurrentPhase(int phase)
    {
        currentPhase = phase;
    }

    public int GetPhase()
    {
        return currentPhase;
    }

    public void OnEnable()
    {
        ScriptSystem.UpdatePhase += CurrentPhase;
    }

    void OnDisable()
    {
        ScriptSystem.UpdatePhase -= CurrentPhase;
    }
}