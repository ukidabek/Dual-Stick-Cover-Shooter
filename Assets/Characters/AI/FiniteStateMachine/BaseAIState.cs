using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAIState : StateMachineBehaviour
{
    protected GameObject GameObject { get => agent.gameObject; }
    protected Transform Transform { get => agent.transform; }
    protected Agent agent = null;

    public virtual void Initialize(Agent agent)
    {
        this.agent = agent;
    }
}