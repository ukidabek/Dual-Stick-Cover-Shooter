using UnityEditor.Animations;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(Animator))]
    public class AIAgent : CharacterController
    {
        [SerializeField] private Animator animator = null;

        protected override void Awake()
        {
            base.Awake();
#if UNITY_EDITOR
            ValidateTransitions();
#endif
            BaseAIState[] baseAIStates = animator.GetBehaviours<BaseAIState>();
            foreach (var item in baseAIStates)
                item.Initialize(this);
        }

#if UNITY_EDITOR
        private void ValidateTransitions()
        {
            for (int i = 0; i < animator.layerCount; i++)
            {
                AnimatorStateMachine stateMachine = (animator.runtimeAnimatorController as AnimatorController).layers[0].stateMachine;
                foreach (ChildAnimatorState childState in stateMachine.states)
                {
                    foreach (AnimatorStateTransition transition in childState.state.transitions)
                    {
                        if (transition.duration > 0)
                        {
                            transition.duration = 0f;
                            Debug.LogAssertionFormat("Transition {0} at state {1} in animator controller {2} has duration time greater than 0!",
                                transform.name, childState.state.name, animator.runtimeAnimatorController.name);
                        }
                    }
                }
            }
        }
#endif
    }
}