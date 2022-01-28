using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/DigDecision")]
public class DigDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        return controller.GetDig();
    }
}