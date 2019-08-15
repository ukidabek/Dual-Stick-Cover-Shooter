using System;
using UnityEngine;

[Serializable]
public class StateActionHandler
{
    [SerializeField] private bool _lock = true;
    private bool locked = false;
    [SerializeField] private AiStateAction[] aiStateActions = null;

    public void Invoke(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (locked) return;
        foreach (var item in aiStateActions)
            item.Perform(animator, animatorStateInfo, layerIndex);
        if (_lock) locked = true;
    }

    public void Reset()
    {
        locked = false;
    }
}
