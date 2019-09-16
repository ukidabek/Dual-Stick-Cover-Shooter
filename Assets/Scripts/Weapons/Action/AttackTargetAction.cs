using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class AttackTargetAction : WeaponAction, IStatGetter
{
    private Weapons.Statistics statistics = null;

    public override void Perform(GameObject user, GameObject target)
    {
        IHit hit = target.GetComponentInChildren<IHit>();
        hit?.DealDamage(statistics.Damage > 0 ? -statistics.Damage : statistics.Damage);
    }

    public void Set(Weapons.Statistics statistics)
    {
        this.statistics = statistics;
    }
}
