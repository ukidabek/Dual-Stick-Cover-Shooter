using System;
using System.Collections;
using Characters.Player;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

public class WeaponPanelController : MonoBehaviour
{
    [SerializeField] private WeaponValue m_weaponValue = null;
    //Tmp
    [SerializeField] private Text _weaponName = null;
    [SerializeField] private Text _clip = null;
    [SerializeField] private Text _magazine = null;

    private IMagazine clip;
    private IAmmunitionStock stock;
    private Coroutine _setUpCourutine;

    private void Awake()
    {
        if(m_weaponValue != null)
            m_weaponValue.OnValueChange += OnWeaponEquipped;
        gameObject.SetActive(false);
    }

    public void OnPlayerAdded(PlayerController playerController)
    {
        return;
        var characterEquipment = playerController.GetComponentInChildren<CharacterEquipment>();
        characterEquipment.WeaponEquipment.OnEquipCallback += OnWeaponEquipped;
        OnWeaponEquipped(characterEquipment.WeaponEquipment.CurrentWeapon);
    }

    private void OnWeaponEquipped(object obj)
    {
        if (obj != null)
            SetUpForWeapon(obj as Weapon);
    }

    private void SetUpForWeapon(Weapon weapon)
    {
        if (clip != null) clip.OnChange -= UpdateClip;

        _weaponName.text = weapon.gameObject.name;
        if (clip != null) clip.OnChange -= UpdateClip;
        clip = weapon.GetComponentInChildren<IMagazine>();

        if (stock != null) stock.OnChange -= UpdateClip;
        stock = weapon.GetComponentInChildren<IAmmunitionStock>();

        if (clip != null)
        {
            UpdateClip(clip.Counter);
            clip.OnChange += UpdateClip;
        }
        else
            _clip.text = "-";
        
        if (stock != null)
        {
            UpdateStock(stock.Counter);
            stock.OnChange += UpdateStock;
        }
        else
            _magazine.text = "-";
    }

    public void UpdateClip(int count) => _clip.text = count.ToString();

    public void UpdateStock(int count) => _magazine.text = count.ToString();
}
