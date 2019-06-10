using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Animations
{
    [RequireComponent(typeof(Animator)), DisallowMultipleComponent]
    public class WeaponUserAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator = null;
        public Animator Animator { get => _animator; }

        public AnimatorOverrideController AnimatorOverrideController { get; private set; }

        private void Awake()
        {
            AnimatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            _animator.runtimeAnimatorController = AnimatorOverrideController;
        }

        private void Reset()
        {
            _animator = gameObject.GetComponent<Animator>();    
        }
    }
}