using AI;
using UnityEngine;

public class TargetRangeValidator : AgentStatusValidator
{
    public enum Validation { In, Out }

    [SerializeField] private Validation validation = Validation.In;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Targets.Count > 0)
        {
            float DistanceToTarget = Vector3.Distance(Targets[0].transform.position, agent.transform.position);

            switch (validation)
            {
                case Validation.In:
                    if (agent.Combat.Range >= DistanceToTarget)
                        actionHandler.Invoke(animator, stateInfo, layerIndex);
                    break;
                case Validation.Out:
                    if (agent.Combat.Range < DistanceToTarget)
                        actionHandler.Invoke(animator, stateInfo, layerIndex);
                    break;
            }
        }
    }
}
