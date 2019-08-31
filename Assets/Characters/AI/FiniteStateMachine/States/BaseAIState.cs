using System.Collections.ObjectModel;
using UnityEngine;

namespace AI
{
    public abstract class BaseAIState : StateMachineBehaviour
    {
        protected GameObject GameObject { get => agent.gameObject; }
        protected Transform Transform { get => agent.transform; }
        protected AIAgent agent = null;

        protected ReadOnlyCollection<GameObject> Targets { get => agent.TargetProvider.Targets; }

        public virtual void Initialize(AIAgent agent)
        {
            this.agent = agent;
        }
    }
}