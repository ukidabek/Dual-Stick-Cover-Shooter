using UnityEngine;

namespace Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private WeaponValueReference _weapon;
        // [SerializeField] private Weapon _weapon = null;
        public Weapon Weapon => _weapon;

        [SerializeField] private WeaponCholder _weaponHolder = null;

        public void GoToPreviousMode() => _weapon?.Value?.PreviusMode();

        public void GoToNextMode() => _weapon?.Value?.NextMode();

        public void Equip(Weapon weapon)
        {
            if (_weapon != null && _weapon.Value != null) _weapon.Value.gameObject.SetActive(false);
            if (weapon == null) return;

            _weapon.Value = weapon;
            if (!_weapon.Value.gameObject.activeSelf) _weapon.Value.gameObject.SetActive(true);
            _weapon.Value.transform.SetParent(_weaponHolder.transform, false);
            _weapon.Value.OnEquip(transform.root.gameObject);
        }

        public void BeginUse() => _weapon?.Value?.BeginUse();

        public void EndUse() => _weapon?.Value?.EndUse();

        public void Use(GameObject target = null) => _weapon?.Value?.Use(target);
    }
}