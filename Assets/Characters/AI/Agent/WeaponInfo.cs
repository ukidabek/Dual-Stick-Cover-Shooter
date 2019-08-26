using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(WeaponController))]
public class WeaponInfo : MonoBehaviour, ICombat
{
    [SerializeField] private WeaponController weaponController = null;

    public bool HasWeapon => throw new System.NotImplementedException();

    public float Range => weaponController.Weapon != null ? weaponController.Weapon.Statistics.Range : 5;

    private void Reset()
    {
        weaponController = GetComponent<WeaponController>();
    }
}
