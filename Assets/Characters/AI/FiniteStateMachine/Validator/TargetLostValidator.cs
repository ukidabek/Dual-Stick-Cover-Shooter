using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLostValidator : AgentStatusValidator
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (Targets.Count == 0)
            actionHandler.Invoke(animator, animatorStateInfo, layerIndex);
    }
}
