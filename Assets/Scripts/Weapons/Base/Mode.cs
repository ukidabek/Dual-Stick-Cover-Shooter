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

            public void Perform(GameObject user, GameObject target = null)
            {
                if (PerformValidationActions())
                    PerformAction(user, target);
            }

            private bool PerformValidationActions()
            {
                foreach (var item in _weaponValidators)
                    if (!item.Validate())
                        return false;
                return true;
            }
            private void PerformAction(GameObject user, GameObject target)
            {
                foreach (var item in _weaponActions)
                    try
                    {
                        item.Perform(user, target);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(string.Format("Object type of {0} throw a exception type of {1}", 
                            item.GetType().Name, e.GetType().Name), item.gameObject);
                    }
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
                weaponEquipActions[i].Equip(user);
        }

        public void BeginUse(GameObject user)
        {
            _onBeginUse.Perform(user);
        }

        public void Use(GameObject user, GameObject target)
        {
            _onUse.Perform(user, target);
        }

        public void EndUse(GameObject user)
        {
            _onEndUse.Perform(user);
        }

        private void OnValidate()
        {
            gameObject.name = _type;
        }
    }
}