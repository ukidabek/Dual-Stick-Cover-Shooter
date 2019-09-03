using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(MagazineAction))]
public class MagazineValidator : WeaponValidator
{
    [SerializeField] private MagazineAction _magazine;

    public override bool Validate()
    {
        return _magazine.Counter > 0;
    }

    private void Reset()
    {
        _magazine = GetComponent<MagazineAction>();
    }
}
