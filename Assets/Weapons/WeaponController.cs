using Mechanic.BaseClasses;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : BaseMechanic, IFire
{
    [SerializeField] private Weapon _weapon = null;

    public void Fire()
    {
        if (_weapon != null && owner.enabled)
            _weapon.Use();
    }
}

