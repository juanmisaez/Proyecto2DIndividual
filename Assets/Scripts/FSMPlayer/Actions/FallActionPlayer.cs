using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/Fall")]
public class FallActionPlayer : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("move", false);
        controller.SetAnimation("fall", true);
        controller.SetAnimation("dig", false);
        controller.SetAnimation("lookDown", false);
        //controller.SetAnimation("climb", false);
    }
}