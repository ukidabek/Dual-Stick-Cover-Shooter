using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "WeaponModeTypeManager", menuName = "Weapon/ModeTypeManager")]
    public class WeaponModeTypeManager : SingletonTypeManager<WeaponModeTypeManager> { }
}