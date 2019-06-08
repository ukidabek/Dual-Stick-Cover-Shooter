using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using Weapons;

public class SpawnProjectileWeaponAction : WeaponAction
{
    private static Dictionary<GameObject, Pool<Transform>> ProjectilesDictionary = new Dictionary<GameObject, Pool<Transform>>();

    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private GameObject _projectile = null;

    private void Awake()
    {
        if (!ProjectilesDictionary.ContainsKey(_projectile))
            ProjectilesDictionary.Add(_projectile, new Pool<Transform>(_projectile.transform, null));
    }

    public override bool Perform()
    {
        Pool<Transform> pool = null;
        if (ProjectilesDictionary.TryGetValue(_projectile, out pool))
        {
            var projectile = pool.Get();
            projectile.transform.position = _spawnPoint.transform.position;
            projectile.transform.rotation = _spawnPoint.transform.rotation;
            projectile.gameObject.SetActive(true);
        }
        return true;
    }
}
