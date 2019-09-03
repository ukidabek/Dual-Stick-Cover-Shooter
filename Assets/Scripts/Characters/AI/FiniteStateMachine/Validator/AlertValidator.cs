using AI;
using UnityEngine;

public class AlertValidator : AgentStatusValidator
{
    [SerializeField] private float alerIncreaseRate = 1f;
    [SerializeField, Range(0f, 1f)] private float alertLevel = 0;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        alertLevel = 0f;
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (alertLevel >= 1f) return;

        if (Targets.Count > 0)
            alertLevel += alerIncreaseRate * Time.deltaTime;
        else
            alertLevel -= alerIncreaseRate * Time.deltaTime;

        alertLevel = Mathf.Clamp(alertLevel, 0f, 1f);

        if (alertLevel >= 1f)
            actionHandler.Invoke(animator, animatorStateInfo, layerIndex);
    }
}
