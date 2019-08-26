using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInRangeValidator : AgentStatusValidator
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Targets.Count > 0)
        {
            float DistanceToTarget = Vector3.Distance(Targets[0].transform.position, agent.transform.position);
            if (agent.Combat.Range >= DistanceToTarget)
                actionHandler.Invoke(animator, stateInfo, layerIndex);
        }
    }
}
