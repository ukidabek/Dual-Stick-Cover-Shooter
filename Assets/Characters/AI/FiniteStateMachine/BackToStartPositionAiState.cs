using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToStartPositionAiState : BaseAIState
{
    private Vector3 startPosition = Vector3.zero;
    [SerializeField] private StateActionHandler actionHandler = new StateActionHandler();

    public override void Initialize(AIAgent agent)
    {
        startPosition = agent.transform.position;
        actionHandler.Reset();
        base.Initialize(agent);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Debug.Log("test");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        agent.Move.MoveToPosition(startPosition);
        if (agent.Move.OnPosition)
            actionHandler.Invoke(animator, animatorStateInfo, layerIndex);
    }

}
