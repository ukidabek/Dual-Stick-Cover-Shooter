using AI;
using UnityEngine;

public class RangeCombatAiState : BaseAIState
{
    [SerializeField] private float targetingSpeed = 5f;
    [SerializeField] private float attackAngle = 40;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        agent.Move.Stop();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Targets.Count > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(Targets[0].transform.position - agent.transform.position, agent.transform.up);
            agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, lookRotation, targetingSpeed);
            if (Quaternion.Angle(agent.transform.rotation, lookRotation) < attackAngle / 2)
                agent.Combat.Attack();
        }
    }
}
