using Mechanic.BaseClasses;
using Player;
using UnityEngine;

namespace Weapons
{
    public class WeaponController : BaseMechanic
    {
        [SerializeField] private Weapon _weapon = null;
        [SerializeField] private WeaponCholder _weaponCholder = null;

        [SerializeField] private bool _fire = false;
        public bool Fire
        {
            get => _fire;
            set
            {
                if (!_fire && owner.Enabled) _weapon?.BeginUse();
                if (_fire && owner.Enabled) _weapon?.EndUse();
                _fire = value;
            }
        }

        public void GoToPreviusMode()
        {
            if (!_fire) _weapon?.PreviusMode();
        }

        public void GoToNextMode()
        {
            if (!_fire) _weapon?.NextMode();
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

        private void OnDisable()
        {
            if (_fire)
                _fire = false;
        }

        public void Update()
        {
            if (_weapon != null && _fire)
                _weapon?.Use();
        }
    }
}