using AI.Actions;
using UnityEngine;

namespace AI
{
    public abstract class WaitForAiState : BaseAIState
    {
        [SerializeField] private StateActionHandler actionHandler = new StateActionHandler();
        public abstract bool Condition { get; }


        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            actionHandler.Reset();
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            if (Condition)
                actionHandler.Invoke(animator, animatorStateInfo, layerIndex);
        }
    }
}