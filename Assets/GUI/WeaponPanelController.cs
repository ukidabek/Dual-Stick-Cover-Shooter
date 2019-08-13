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
        stock = weapon.GetComponentInChildren<IAmmunitionStock>();

        if (clip != null)
        {
            UpdateClip(clip.Counter);
            clip.OnCounterChange += UpdateClip;
        }
        else
            _clip.text = "-";

        if (stock != null)
        {
            UpdateStock(stock.Counter);
            stock.OnStackChange += UpdateStock;
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
