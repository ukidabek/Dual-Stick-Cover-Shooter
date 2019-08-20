using UnityEngine;

public abstract class SetAnimatoirParameterAiStateAction : AiStateAction
{
    [SerializeField] protected string _parametrName = "Name";
    protected int _hash = 0;

    public override void Perform(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (_hash == 0)
            _hash = Animator.StringToHash(_parametrName);
        Set(animator);
    }

    protected abstract void Set(Animator animator);

}
