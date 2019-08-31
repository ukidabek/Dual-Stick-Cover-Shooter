using System;
using UnityEngine;

namespace AI.Actions
{
    [Serializable]
    public class StateActionHandler
    {
        [SerializeField] private bool _lock = true;
        private bool locked = false;
        [SerializeField] private AIStateAction[] Actions = null;

        public void Invoke(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            if (locked) return;

            foreach (var item in Actions)
                item.Perform(animator, animatorStateInfo, layerIndex);

            if (_lock) locked = true;
        }

        public void Reset()
        {
            locked = false;
        }
    }
}