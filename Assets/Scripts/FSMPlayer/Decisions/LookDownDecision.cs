using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/LookDownDecision")]
public class LookDownDecision : FSM.Decision
{
    bool lookDown;

    public override bool Decide(Controller controller)
    {
        float y = controller.GetMoveY();
        float x = controller.GetMoveX();
        bool d = controller.GetDig();

        if (y == -1 && x == 0 && !d) // Mira abajo si no está en movimiento ni está picando
        {
            lookDown = true;
        }
        else
        {
            lookDown = false;
        }
        return lookDown;
    }
}