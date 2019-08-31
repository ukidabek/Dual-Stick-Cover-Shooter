using AI;
using UnityEngine;

public class TargetAutOfRangeValidator : AgentStatusValidator
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Targets.Count > 0)
        {
            float DistanceToTarget = Vector3.Distance(Targets[0].transform.position, agent.transform.position);
            if (agent.Combat.Range < DistanceToTarget)
                actionHandler.Invoke(animator, stateInfo, layerIndex);
        }
    }
}
