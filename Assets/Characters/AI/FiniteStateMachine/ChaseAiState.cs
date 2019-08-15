using System.Collections;
using UnityEngine;

public class ChaseAiState : TargetHandlingAiState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (targets.Count > 0)
            agent.Move.MoveToPosition(targets[0].transform.position);
    }
}
