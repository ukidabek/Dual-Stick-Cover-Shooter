using UnityEngine;

namespace AI.Actions
{
    public abstract class AIStateActionTask
    {
        public abstract void Perform(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex);
    }
}
