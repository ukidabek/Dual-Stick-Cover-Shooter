using System;
using Mechanic.BaseClasses;
using Player;
using UnityEngine;

namespace Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon = null;
        [SerializeField] private WeaponCholder _weaponCholder = null;

        public void GoToPreviusMode()
        {
            _weapon?.PreviusMode();
        }

        public void GoToNextMode()
        {
            _weapon?.NextMode();
        }

        public void Equip(Weapon weapon)
        {
            if (_weapon != null) _weapon.gameObject.SetActive(false);
            if (weapon != null)
            {
                _weapon = weapon;
                if (!_weapon.gameObject.activeSelf) _weapon.gameObject.SetActive(true);
                _weapon.transform.SetParent(_weaponCholder.transform, false);
                _weapon.OnEquip(transform.root.gameObject);
            }
        }


        internal void BeginUse()
        {
            _weapon?.BeginUse();
        }

        internal void EndUse()
        {
            _weapon?.EndUse();
        }

        internal void Use()
        {
            _weapon?.Use();
        }
    }
}