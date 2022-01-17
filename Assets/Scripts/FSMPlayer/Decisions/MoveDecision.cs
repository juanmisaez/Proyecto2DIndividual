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

        if (x != 0 && !d) // Está en movimiento siempre que no esté picando
        {
            move = true;
        }
        else// if(x == 0) // Está quieto
        {
            move = false;
        }
        return move;
    }
}