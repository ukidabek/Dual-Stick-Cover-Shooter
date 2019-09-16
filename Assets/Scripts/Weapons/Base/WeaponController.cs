using System;
using Mechanic.BaseClasses;
using Player;
using UnityEngine;

namespace Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon = null;
        public Weapon Weapon { get => _weapon; }
        
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

        public void BeginUse()
        {
            _weapon?.BeginUse();
        }

        public void EndUse()
        {
            _weapon?.EndUse();
        }

        public void Use(GameObject target = null)
        {
            _weapon?.Use(target);
        }
    }
}