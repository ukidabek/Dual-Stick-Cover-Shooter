using UnityEngine;
using Utilities.General;
using Weapons;

public class SpawnProjectileWeaponAction : WeaponAction, IStatGetter
{
    private Pool<Projectile> pool = null;
    private Weapons.Statistics statistics = null;

    [Space]
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private Projectile _projectile = null;

    private void Awake()
    {
        pool = new Pool<Projectile>(_projectile, null);
    }

    public override void Perform(GameObject user, GameObject target = null)
    {
        var projectile = pool.Get();
        projectile.transform.position = _spawnPoint.transform.position;
        projectile.transform.rotation = _spawnPoint.transform.rotation;
        projectile.Setup(statistics.Damage, statistics.Range);
        projectile.gameObject.SetActive(true);
    }

    public void Set(Weapons.Statistics statistics)
    {
        this.statistics = statistics;
    }
}
