using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class TmpWeaponEquip : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private Weapon _weapon = null;

    void Start()
    {
        _weaponController?.EquipWeapon(Instantiate(_weapon));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
