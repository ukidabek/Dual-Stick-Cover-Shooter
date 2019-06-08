using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons
{
    [Serializable] public class OnModeSwitchCallback : UnityEvent<Mode> { }

    public partial class Weapon : MonoBehaviour
    {

        [SerializeField] private int _currentModeIndex = 0;
        [SerializeField] private Mode[] _modes = null;

        public OnModeSwitchCallback OnModeSwitch = new OnModeSwitchCallback();
        public Mode SeledtedMode { get => _modes == null || _modes.Length == 0 ? null : _modes[_currentModeIndex]; }

        public void OnEquip(GameObject user)
        {
            for (int i = 0; i < _modes.Length; i++) _modes[i].OnWeaponEquip(user);
        }

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

        public void NextMode()
        {
            if (++_currentModeIndex > _modes.Length - 1)
                _currentModeIndex = 0;
            OnModeSwitch.Invoke(SeledtedMode);
        }

        public void PreviusMode()
        {
            if (--_currentModeIndex < 0)
                _currentModeIndex = _modes.Length - 1;
            OnModeSwitch.Invoke(SeledtedMode);
        }
    }
}