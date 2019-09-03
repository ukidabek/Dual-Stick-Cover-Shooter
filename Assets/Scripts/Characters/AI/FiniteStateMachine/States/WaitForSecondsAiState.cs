using UnityEngine;

namespace AI
{
    public class WaitForSecondsAiState : WaitForAiState
    {
        [SerializeField] private float _time = 1f;
        [SerializeField] private float _counter = 0;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            _counter = _time;
            base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        }

        public override bool Condition => _counter <= 0f;

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            _counter -= Time.deltaTime;
            base.OnStateUpdate(animator, animatorStateInfo, layerIndex);
        }
    }
}