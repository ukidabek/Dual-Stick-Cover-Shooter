using BaseGameLogic.Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Animations
{
    public class WeaponAnimationOverrideAction : MonoBehaviour, IWeaponEquipAction
    {
        [SerializeField] private Override[] overrides = new Override[0];

        public void Equip(GameObject gameObject)
        {
            WeaponUserAnimator _userAnimator = gameObject.GetComponentInChildren<WeaponUserAnimator>();
            if (_userAnimator != null && _userAnimator.AnimatorOverrideController != null)
                foreach (var item in overrides)
                    _userAnimator.OverrideAnimation(item);
        }
    }
}