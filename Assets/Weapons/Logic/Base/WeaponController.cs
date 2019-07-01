using Mechanic.BaseClasses;
using Player;
using UnityEngine;

namespace Weapons
{
    public class WeaponController : BaseMechanic, IFire
    {
        [SerializeField] private Weapon _weapon = null;
        [SerializeField] private Transform _weaponCholder = null;

        [SerializeField] private bool _activate = false;
        public bool Activate
        {
            get => _activate;
            set
            {
                if (!_activate && owner.Enabled) _weapon?.BeginUse();
                if (_activate && owner.Enabled) _weapon?.EndUse();
                _activate = value;
            }
        }

        public void GoToPreviusMode()
        {
            if (!_activate) _weapon?.PreviusMode();
        }

        public void GoToNextMode()
        {
            if (!_activate) _weapon?.NextMode();
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

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnDisable()
        {
            if (_activate)
                _activate = false;
        }

        public void Update()
        {
            if (_weapon != null && _activate)
                _weapon?.Use();
        }
    }
}