using Mechanic.BaseClasses;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class WeaponController : BaseMechanic, IFire
    {
        [SerializeField] private Weapon _weapon = null;
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

        protected override void Awake()
        {
            base.Awake();
            _weapon?.OnEquip(transform.root.gameObject);
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