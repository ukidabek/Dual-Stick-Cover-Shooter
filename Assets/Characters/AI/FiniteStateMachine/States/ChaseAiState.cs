using AI;
using UnityEngine;

public class ChaseAiState : BaseAIState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (Targets.Count > 0)
            agent.Move.Set(Targets[0].transform.position);
    }
}
