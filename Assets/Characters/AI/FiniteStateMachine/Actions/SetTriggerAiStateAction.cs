using UnityEngine;

public class SetTriggerAiStateAction : SetAnimatoirParameterAiStateAction
{
    protected override void Set(Animator animator)
    {
        animator.SetTrigger(_hash);
    }
}