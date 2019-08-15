using Mechanic.BaseClasses;
using UnityEngine;

namespace Weapons
{
    public class WeaponInvoker : BaseMechanic
    {
        [SerializeField] private WeaponController _weaponController = null;
        [SerializeField] private bool _fire = false;
        public bool Fire
        {
            get => _fire;
            set
            {
                if (!_fire && owner.Enabled) _weaponController?.BeginUse();
                if (_fire && owner.Enabled) _weaponController?.EndUse();
                _fire = value;
            }
        }

        public void Update()
        {
            if ( _fire)
                _weaponController?.Use();
        }

        private void OnDisable()
        {
            if (_fire)
                _fire = false;
        }
    }
}