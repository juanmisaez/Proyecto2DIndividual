using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/DigDecision")]
public class DigDecision : FSM.Decision
{
    bool dig;

    public override bool Decide(Controller controller)
    {
        bool d = controller.GetDig();
        float x = controller.GetMoveX();

        if (d && x==0)
        { 
            dig = true;
        }
        else
        {
            dig = false;
        }

        return dig;
    }
}