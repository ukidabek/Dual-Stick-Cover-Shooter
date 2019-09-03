using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Weapons
{
    [CustomPropertyDrawer(typeof(Mode.Type), true)]
    public class WeaponModeTypePropertyDrower : TypePropertyDrower<WeaponModeTypeManager> { }
}