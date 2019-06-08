using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public interface IWeaponEquipAction
    {
        void Perform(GameObject gameObject);
    }
}
