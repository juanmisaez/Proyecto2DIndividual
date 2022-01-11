using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/Move")]
public class MoveActionPlayer : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("move", true);
        controller.SetAnimation("fall", false);
        //controller.SetAnimation("dig", false);
        //controller.SetAnimation("climb", false);
    }
}