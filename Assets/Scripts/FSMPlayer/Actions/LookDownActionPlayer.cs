using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/LookDown")]
public class LookDownActionPlayer : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("move", false);
        controller.SetAnimation("fall", false);
        controller.SetAnimation("dig", false);
        controller.SetAnimation("lookDown", true);
        //controller.SetAnimation("climb", false);
    }
}