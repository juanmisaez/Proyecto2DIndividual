using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decisions/DigEndDecision")]
public class DigEndDecision : FSM.Decision
{
    Animator animator;

    public override bool Decide(Controller controller)
    {
        animator = controller.gameObject.GetComponent<Animator>();

        return !animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerDig");
    }
}