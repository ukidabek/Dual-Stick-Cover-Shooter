using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private List<WeaponValidator> _weaponValidators = new List<WeaponValidator>();
    [SerializeField] private List<WeaponAction> _weaponActions = new List<WeaponAction>();

    public void Use()
    {
        bool canBeUsed = true;
        foreach (var item in _weaponValidators)
            if (!item.Validate())
            {
                canBeUsed = false;
                break;
            }

        if (canBeUsed)
            foreach (var item in _weaponActions)
                item.Perform();
    }
}
