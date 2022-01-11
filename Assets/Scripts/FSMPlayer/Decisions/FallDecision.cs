using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/FallDecision")]
public class FallDecision : FSM.Decision
{
    bool fall;

    public override bool Decide(Controller controller)
    {
        bool y = controller.GetFall();

        if (y == true) // Está cayendo
        {
            fall = true;
            Debug.Log("Estoy cayendo");
        }
        else // Está en el suelo
        {
            fall = false;
            Debug.Log("Estoy en el suelo");
        }        
        return fall;
    }
}