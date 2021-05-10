using System;
using UnityEngine;
using Utilities.Values;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Values/Weapon")]
    public class WeaponValue : BaseValue<Weapon>
    {
    }

    [Serializable]
    public class WeaponValueReference : BaseValueReference<WeaponValue, Weapon>
    {
    }
}