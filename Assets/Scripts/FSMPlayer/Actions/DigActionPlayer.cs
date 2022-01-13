using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/Dig")]
public class DigActionPlayer : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("move", false);
        controller.SetAnimation("fall", false);
        controller.SetAnimation("dig", true);
        //controller.SetAnimation("climb", false);
    }
}