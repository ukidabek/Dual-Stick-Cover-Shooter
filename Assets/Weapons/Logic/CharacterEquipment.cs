using System.Collections;
using UnityEngine;
using Weapons;

public interface IEquipment
{
    void Equip(object equipmentPiece);
    void Add(object equipmentPiece);
    void Remowe(object equipmentPiece);
}

public interface IWeaponEquipment : IEquipment
{
    void Next();
    void Previous();
    void Select(int index);
}

public class CharacterEquipment : MonoBehaviour
{
    private IWeaponEquipment _weaponEquipment = null;

    private void Awake()
    {
        _weaponEquipment = GetComponent<IWeaponEquipment>();
    }

    private void Reset()
    {
        gameObject.name = GetType().Name;
    }
}
