using UnityEngine;

namespace Weapons.Animations
{
    public class WeaponAnimationParametrSeter : WeaponAction, IWeaponEquipAction
    {
        public enum ParametrToSet { Trigger, Bool }

        [SerializeField] private ParametrToSet _parametrToSet = ParametrToSet.Bool;

        [SerializeField] private string _parametrName = string.Empty;
        private int _parametrHash = 0;
        private WeaponUserAnimator _userAnimator = null;
        [SerializeField, HideInInspector] private bool _boolValue = false;

        public void SetTrigger()
        {
            _userAnimator?.Animator.SetTrigger(_parametrHash);
        }

        public void SetBool()
        {
            _userAnimator?.Animator.SetBool(_parametrHash, _boolValue);
        }

        private void Awake()
        {
            _parametrHash = Animator.StringToHash(_parametrName);
        }

        public void Perform(GameObject gameObject)
        {
            _userAnimator = gameObject.GetComponentInChildren<WeaponUserAnimator>();
        }

        public override bool Perform()
        {
            switch (_parametrToSet)
            {
                case ParametrToSet.Trigger:
                    SetTrigger();
                    break;
                case ParametrToSet.Bool:
                    SetBool();
                    break;
            }
            return true;
        }
    }
}