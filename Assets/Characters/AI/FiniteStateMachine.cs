using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected FiniteStateMachine stateMachine = null;
    
    public State(FiniteStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public abstract Type Update();
    public virtual void Exit() { }
}

public class MoveToRandomPointState : State
{
    public MoveToRandomPointState(FiniteStateMachine stateMachine) : base(stateMachine) { }

    public override Type Update()
    {
        throw new NotImplementedException();
    }
}

public class IdleState : State
{
    private float idleTime = 1f;

    private float counter = 0;

    public IdleState(FiniteStateMachine stateMachine, float idleTime) : base(stateMachine)
    {
        this.idleTime = idleTime;
    }

    public override void Enter()
    {
        counter = idleTime;
    }

    public override Type Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
            return typeof(MoveToRandomPointState);
        return null;
    }
}

[RequireComponent(typeof(Agent))]
public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] private Agent agent = null;
    public Agent Agent { get => agent; }

    private State CurrentState = null;

    public void Update()
    {
        CurrentState?.Update();
    }

    private void Reset()
    {
        agent = gameObject.GetComponent<Agent>();
    }
}
