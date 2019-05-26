using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : WeaponAction
{
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private GameObject _projectile = null;

    public override bool Perform()
    {
        Instantiate(_projectile, _spawnPoint.position, _spawnPoint.rotation);
        return true;
    }
}
