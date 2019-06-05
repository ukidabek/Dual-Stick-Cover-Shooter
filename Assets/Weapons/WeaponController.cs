using Mechanic.BaseClasses;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : BaseMechanic, IFire
{
    [SerializeField] private Weapon _weapon = null;

    [SerializeField] private bool _activate = false;
    public bool Activate
    {
        get => _activate;
        set
        {
            if (!_activate && owner.Enabled) Debug.Log("a");
            if (_activate && owner.Enabled) Debug.Log("b");
            _activate = value;
        }
    }

    private void OnDisable()
    {
        if(_activate)
        {
            _activate = false;
            Debug.Log("c");
        }
    }

    public void Update()
    {
        if (_weapon != null && _activate)
            _weapon.Use();
    }
}

