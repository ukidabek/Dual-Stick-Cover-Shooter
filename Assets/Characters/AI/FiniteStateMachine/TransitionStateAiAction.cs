using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionStateAiAction : AiStateAction
{
    [SerializeField] private Status status = Status.Idle;

    public override void Perform(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetTrigger(status.ToString());
    }
}
