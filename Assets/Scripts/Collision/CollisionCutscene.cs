using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCutscene : CollisionSystem
{    
    [SerializeField]
    private int phase; // si la tiene el padre, no har�a falta

    protected override void OnCollision(Collider2D other)
    {        
        other.gameObject.GetComponent<PhaseSystem>()?.PhaseUpdate(phase);
        //GetComponent<ScriptSystem>().PhaseSelection(phase);
    }
}