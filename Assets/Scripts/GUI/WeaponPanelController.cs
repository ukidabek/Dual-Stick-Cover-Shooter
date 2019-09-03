using Characters.Player;
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
    private IAmmunitionStock stock;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void OnPlayerAdded(PlayerController playerController)
    {
        var characterEquipment = playerController.GetComponentInChildren<CharacterEquipment>();
        characterEquipment.WeaponEquipment.OnEquipCallback += OnWeaponEquped;
        OnWeaponEquped(characterEquipment.WeaponEquipment.CurrentWeapon);
    }

    private void OnWeaponEquped(object obj)
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

    public void UpdateClip(int count)
    {
        _clip.text = count.ToString();
    }

    public void UpdateStock(int count)
    {
        _magazine.text = count.ToString();
    }
}
