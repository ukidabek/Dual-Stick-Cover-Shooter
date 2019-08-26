using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AIAgent : CharacterController
{
    [SerializeField] private Animator animator = null;

    protected override void Awake()
    {
        base.Awake();

        BaseAIState[] baseAIStates = animator.GetBehaviours<BaseAIState>();
        foreach (var item in baseAIStates)
            item.Initialize(this);
    }
}
