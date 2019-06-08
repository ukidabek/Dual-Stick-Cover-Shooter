using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [DisallowMultipleComponent]
    public class Mode : MonoBehaviour
    {
        [Serializable]
        public class Type : BaseGameLogic.Singleton.Type { }

        [SerializeField] private Type _type = new Type();
        public Type GetModeType()
        {
            return _type;
        }

        [Serializable]
        public class WeaponLogicModule
        {
            [SerializeField] private List<WeaponValidator> _weaponValidators = new List<WeaponValidator>();
            [SerializeField] private List<WeaponAction> _weaponActions = new List<WeaponAction>();

            private bool _canBeUsed = true;

            public void Perform()
            {
                _canBeUsed = true;
                foreach (var item in _weaponValidators)
                    if (!item.Validate())
                    {
                        _canBeUsed = false;
                        break;
                    }

                if (_canBeUsed)
                    foreach (var item in _weaponActions)
                        item.Perform();
            }
        }

        [SerializeField] private WeaponLogicModule _onBeginUse = new WeaponLogicModule();
        [SerializeField] private WeaponLogicModule _onUse = new WeaponLogicModule();
        [SerializeField] private WeaponLogicModule _onEndUse = new WeaponLogicModule();
        private IWeaponEquipAction[] weaponEquipActions = null;

        private void Awake()
        {
            weaponEquipActions = this.gameObject.GetComponentsInChildren<IWeaponEquipAction>();
        }

        public void OnWeaponEquip(GameObject user)
        {
            for (int i = 0; i < weaponEquipActions.Length; i++)
                weaponEquipActions[i].Perform(user);
        }

        public void BeginUse()
        {
            _onBeginUse.Perform();
        }

        public void Use()
        {
            _onUse.Perform();
        }

        public void EndUse()
        {
            _onEndUse.Perform();
        }

        private void OnValidate()
        {
            gameObject.name = _type;
        }
    }
}