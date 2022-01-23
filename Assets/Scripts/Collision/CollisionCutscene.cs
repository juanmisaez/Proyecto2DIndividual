using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCutscene : CollisionSystem
{    
    [SerializeField]
    private int phase; // si la tiene el padre, no haría falta

    protected override void OnCollision(Collider2D other)
    {        
        other.gameObject.GetComponent<PhaseSystem>()?.PhaseUpdate(GetPhase());
    }

    void CurrentPhase(int newPhase) // Actualiza la fase que le dice el ScriptSystem
    {
        phase = newPhase;
    }

    public int GetPhase()
    {
        return phase;
    }

    void OnEnable()
    {
        ScriptSystem.UpdatePhase += CurrentPhase; // int
    }

    void OnDisable()
    {
        ScriptSystem.UpdatePhase -= CurrentPhase; // int
    }
}