using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using Weapons;


public class SpawnProjectileWeaponAction : WeaponAction, IStatGetter
{
    private static Dictionary<GameObject, Pool<Projectile>> ProjectilesDictionary = new Dictionary<GameObject, Pool<Projectile>>();
    private Weapons.Statistics statistics = null;

    [Space]
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private Projectile _projectile = null;

    private void Awake()
    {
        if (!ProjectilesDictionary.ContainsKey(_projectile.gameObject))
            ProjectilesDictionary.Add(_projectile.gameObject, new Pool<Projectile>(_projectile, null));
    }

    public override bool Perform(GameObject user)
    {
        Pool<Projectile> pool = null;
        if (ProjectilesDictionary.TryGetValue(_projectile.gameObject, out pool))
        {
            var projectile = pool.Get();
            projectile.transform.position = _spawnPoint.transform.position;
            projectile.transform.rotation = _spawnPoint.transform.rotation;
            projectile.Setup(statistics.Damage, statistics.Range);
            projectile.gameObject.SetActive(true);
        }
        return true;
    }

    public void Set(Weapons.Statistics statistics)
    {
        this.statistics = statistics;
    }
}
