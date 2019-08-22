using System;
using System.Collections;
using System.Collections.Generic;
using BaseGameLogic.Animations;
using UnityEngine;

namespace Weapons.Animations
{
    [DisallowMultipleComponent]
    public class WeaponUserAnimator : MonoBehaviour
    {
        private Queue<Override> overrides = new Queue<Override>();

        [SerializeField] private Animator _animator = null;
        public Animator Animator { get => _animator; set => InitializeAnimator(value); }

        public AnimatorOverrideController AnimatorOverrideController { get; private set; }

        private void Start()
        {
            InitializeAnimator();
        }

        private void InitializeAnimator(Animator animator = null)
        {
            if (animator != null && animator != _animator)
                _animator = animator;

            if (_animator != null)
            {
                if(_animator.runtimeAnimatorController is AnimatorOverrideController)
                    AnimatorOverrideController = _animator.runtimeAnimatorController as AnimatorOverrideController;
                else
                {
                    AnimatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
                    _animator.runtimeAnimatorController = AnimatorOverrideController;
                    _animator.Rebind();
                }
            }
        }

        public void OverrideAnimation(Override @override)
        {
            overrides.Enqueue(new Override(@override.AnimationClip.name, AnimatorOverrideController[@override.AnimationName]));
            AnimatorOverrideController[@override.AnimationName] = @override.AnimationClip;
        }

        public void ResetAnimationOverrides()
        {
            while (overrides.Count > 0)
            {
                var @override = overrides.Dequeue();
                AnimatorOverrideController[@override.AnimationName] = @override.AnimationClip;
            }
        }

        private void Reset()
        {
            _animator = gameObject.GetComponent<Animator>();
        }
    }
}