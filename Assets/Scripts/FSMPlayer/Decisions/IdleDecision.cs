using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/IdleDecision")]
public class IdleDecision : FSM.Decision
{
    bool idle;

    public override bool Decide(Controller controller)
    {        
        float x = controller.GetMoveX();
        float y = controller.GetMoveY();
        bool f = controller.GetFall();
        bool d = controller.GetDig();

        if (x == 0 && y == 0 && !f && !d)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }
        return idle;
    }
}