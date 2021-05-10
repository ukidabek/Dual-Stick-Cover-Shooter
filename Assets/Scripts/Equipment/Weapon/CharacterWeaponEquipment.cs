using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class CharacterWeaponEquipment : MonoBehaviour, IWeaponEquipment
{
    [SerializeField] private WeaponController _weaponController = null;

    //Tmp
    [SerializeField] private int _selectedWeaponIndex = 0;
    [SerializeField] private List<Weapon> weaponsPrefabs = new List<Weapon>();
    private List<Weapon> weapons = new List<Weapon>();

    public event Action<object> OnEquipCallback = null;

    public object CurrentWeapon => weapons[_selectedWeaponIndex];

    private void Start()
    {
        foreach (var _weapon in weaponsPrefabs)
        {
            var currentWeapon = Instantiate(_weapon);
            currentWeapon.transform.position = Vector3.zero;
            currentWeapon.gameObject.SetActive(false);
            weapons.Add(currentWeapon);
        }

        StartCoroutine(EquipCoroutine());
    }

    // Tmp
    private System.Collections.IEnumerator EquipCoroutine()
    {
        yield return new WaitForEndOfFrame();
        Equip(weapons[_selectedWeaponIndex]);
    }

    public void Add(object equipmentPiece) { }

    public void Equip(object equipmentPiece)
    {
        if (equipmentPiece != null && equipmentPiece is Weapon weapon)
        {
            _weaponController.Equip(weapon);
            OnEquipCallback?.Invoke(weapon);
        }
    }

    public void Next()
    {
        _selectedWeaponIndex = ++_selectedWeaponIndex % weapons.Count;
        Equip(weapons[_selectedWeaponIndex]);
    }

    public void Previous()
    {
        --_selectedWeaponIndex;
        _selectedWeaponIndex = _selectedWeaponIndex < 0 ? weapons.Count - 1 : _selectedWeaponIndex;
        Equip(weapons[_selectedWeaponIndex]);
    }

    public void Remove(object equipmentPiece) { }

    public void Select(int index)
    {
        Equip(weapons[_selectedWeaponIndex = index]);
    }

    private void OnValidate() { }
}
