using AI.Actions;
using UnityEngine;

namespace AI
{
    public abstract class AgentStatusValidator : BaseAIState
    {
        [SerializeField] protected StateActionHandler actionHandler = null;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            actionHandler.Reset();
        }
    }
}