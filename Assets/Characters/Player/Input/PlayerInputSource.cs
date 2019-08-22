using Characters.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSource : MonoBehaviour
{
    [SerializeField] private int assignedPlayerID = 0;

    private PlayerController playerController { get => PlayerController.Players[assignedPlayerID]; }

    public void Move(Vector3 input)
    {
        playerController.Move.Set(input);
    }

    public void Look(Vector3 input)
    {
        playerController.Look.Set(input);
    }

    public void Aim(bool input)
    {
        playerController.Aim.Activate(input);
    }

    public void Attack(bool input)
    {
        playerController.Weapon.Activate(input);
    }

    public void Use()
    {
        playerController.Use.Activate();
    }

    public void NextWeapon()
    {
        playerController.Weapon.Next();
    }

    public void PreviousWeapon()
    {
        playerController.Weapon.Previous();
    }

    public void NextWeaponMode()
    {
        playerController.Weapon.NextMode();
    }

    public void PreviousWeaponMode()
    {
        playerController.Weapon.PreviousMode();
    }
}
