using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/Idle")]
public class IdleActionPlayer : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", true);
        controller.SetAnimation("move", false);
        controller.SetAnimation("fall", false);
        controller.SetAnimation("dig", false);
        //controller.SetAnimation("climb", false);
    }
}