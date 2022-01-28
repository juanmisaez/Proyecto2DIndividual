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
        /*bool y = controller.GetFall();
        //bool d = controller.GetDig();

        if (y /*&& !d) // Está cayendo
        {
            fall = true;
        }
        else // Está en el suelo
        {
            fall = false;
        }    */    
        return controller.GetFall(); ;
    }
}