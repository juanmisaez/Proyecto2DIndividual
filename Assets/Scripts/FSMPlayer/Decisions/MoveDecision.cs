using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/MoveDecision")]
public class MoveDecision : FSM.Decision
{
    bool move;

    public override bool Decide(Controller controller)
    {
        float x = controller.GetMoveX();
        bool d = controller.GetDig();
        bool y = controller.GetFall();

        if (x != 0 && !d && !y) // Est� en movimiento siempre que no est� picando ni cayendo
        {
            move = true;
        }
        else// if(x == 0) // Est� quieto
        {
            move = false;
        }
        return move;
    }
}