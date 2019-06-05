using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Serializable]
    public class Mode
    {
        [Serializable]
        public class Type
        {
            [SerializeField] private string _name = string.Empty;

            public static bool operator ==(Type a, Type b)
            {
                return a._name == b._name;
            }

            public static bool operator !=(Type a, Type b)
            {
                return a._name != b._name;
            }

            public override bool Equals(object obj)
            {
                return (obj as Type) == this;
            }

            public override int GetHashCode()
            {
                return _name.GetHashCode();
            }

            public static implicit operator string(Type type)
            {
                return type._name;
            }
        }

        [SerializeField] private Type type = new Type();
        public Type Type1 { get => type; }

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
    }

    [SerializeField] private int _currentModeIndex = 0;
    [SerializeField] private Mode[] _modes = new Mode[1];

    public void BeginUse()
    {
        _modes[_currentModeIndex].BeginUse();
    }

    public void Use()
    {
        _modes[_currentModeIndex].Use();
    }

    public void EndUse()
    {
        _modes[_currentModeIndex].EndUse();
    }
}
