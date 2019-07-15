using System.Collections;
using UnityEngine;
using Weapons;

public class CharacterEquipment : MonoBehaviour
{
    private IWeaponEquipment _weaponEquipment = null;
    public IWeaponEquipment WeaponEquipment { get => _weaponEquipment; }

    private void Awake()
    {
        _weaponEquipment = GetComponentInChildren<IWeaponEquipment>();
    }

    private void Reset()
    {
        gameObject.name = GetType().Name;
    }

    public void NextWeapon()
    {
        _weaponEquipment?.Next();
    }

    public void PreviousWeapon()
    {
        _weaponEquipment?.Previous();
    }
}
