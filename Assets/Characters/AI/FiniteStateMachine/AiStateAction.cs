using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiStateAction : StateMachineBehaviour
{
    public abstract void Perform(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex);
}
