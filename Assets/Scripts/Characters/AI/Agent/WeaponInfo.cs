using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(WeaponController))]
public class WeaponInfo : MonoBehaviour, ICombat
{
    [SerializeField] private WeaponController weaponController = null;

    public bool HasWeapon => weaponController.Weapon != null;

    public float Range => HasWeapon ? weaponController.Weapon.Statistics.Range : 5;

    public void Attack(GameObject target = null)
    {
        if (HasWeapon)
            weaponController.Use(target);
    }
}
