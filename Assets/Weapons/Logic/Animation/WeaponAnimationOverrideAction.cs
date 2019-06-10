using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Animations
{
    public class WeaponAnimationOverrideAction : MonoBehaviour, IWeaponEquipAction
    {
        [Serializable]
        public class Override
        {
            [SerializeField] private string animationName = string.Empty;
            public string AnimationName { get => animationName; }

            [SerializeField] private AnimationClip animationClip = null;
            public AnimationClip AnimationClip { get => animationClip; }
        }

        [SerializeField] private Override[] overrides = new Override[0];

        public void Perform(GameObject gameObject)
        {
            WeaponUserAnimator _userAnimator = gameObject.GetComponentInChildren<WeaponUserAnimator>();
            if(_userAnimator != null && _userAnimator.AnimatorOverrideController != null)
                foreach (var item in overrides)
                    _userAnimator.AnimatorOverrideController[item.AnimationName] = item.AnimationClip;
        }
    }
}