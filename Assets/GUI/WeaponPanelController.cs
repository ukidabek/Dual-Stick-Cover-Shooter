using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

public class WeaponPanelController : MonoBehaviour
{
    //Tmp
    [SerializeField] private Text _weaponName = null;
    [SerializeField] private Text _clip = null;
    [SerializeField] private Text _magazine = null;

    private IMagazine clip;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void OnPlayerAdded(PlayerController playerController)
    {
        var cheq = playerController.GetComponentInChildren<CharacterEquipment>();
        cheq.WeaponEquipment.OnEquipCallback += OnWeaponEquped;
        OnWeaponEquped(cheq.WeaponEquipment.CurrentWeapon);
    }

    private void OnWeaponEquped(object obj)
    {
        if (obj != null)
            SetUpForWeapon(obj as Weapon);
    }

    private void SetUpForWeapon(Weapon weapon)
    {
        if (clip != null) clip.OnCounterChange -= UpdateClip;

        _weaponName.text = weapon.gameObject.name;
        clip = weapon.GetComponentInChildren<IMagazine>();

        if (clip != null)
        {
            UpdateClip(clip.Counter);
            clip.OnCounterChange += UpdateClip;
        }
        else
            _clip.text = "-";
    }

    public void UpdateClip(int count)
    {
        _clip.text = count.ToString();
    }
}
