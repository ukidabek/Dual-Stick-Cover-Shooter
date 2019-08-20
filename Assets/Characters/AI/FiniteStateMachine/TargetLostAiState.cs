using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLostAiState : BaseAIState
{
    [SerializeField] private StateActionHandler actionHandler = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        actionHandler.Reset();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (Targets.Count == 0)
            actionHandler.Invoke(animator, animatorStateInfo, layerIndex);
    }
}
