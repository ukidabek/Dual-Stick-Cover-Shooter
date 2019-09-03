using UnityEngine;

namespace AI.Actions
{
    public class SetAnimatorTriggerTask : AIStateActionTask
    {
        private int triggerHash = 0;

        public SetAnimatorTriggerTask(string triggerName)
        {
            triggerHash = Animator.StringToHash(triggerName);
        }

        public override void Perform(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            animator.SetTrigger(triggerHash);
        }
    }
}
