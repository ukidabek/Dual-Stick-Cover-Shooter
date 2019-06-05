using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponModeTypeManager", menuName = "Weapon/ModeTypeManager")]
public class WeaponModeTypeManager : SingletonScriptableObject<WeaponModeTypeManager>
{
    protected override void Initialize()
    {
        TypesNames = new ReadOnlyCollection<string>(_typesNames);
    }

    [SerializeField] private List<string> _typesNames = new List<string>();
    public ReadOnlyCollection<string> TypesNames { get; private set; }
}
