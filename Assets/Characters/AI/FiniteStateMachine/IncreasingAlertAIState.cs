using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasingAlertAIState : TargetHandlingAiState
{
    [SerializeField] private float air = 1f;
    [SerializeField, Range(0f, 1f)] private float alert = 0;
    [Space]
    [SerializeField] private StateActionHandler actionHandler = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        alert = 0f;
        actionHandler.Reset();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (alert >= 1f) return;

        if (targets.Count > 0)
            alert += air * Time.deltaTime;
        else
            alert -= air * Time.deltaTime;

        alert = Mathf.Clamp(alert, 0f, 1f);

        if (alert >= 1f)
            actionHandler.Invoke(animator, animatorStateInfo, layerIndex);
    }
}
