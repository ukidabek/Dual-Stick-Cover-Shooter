using UnityEngine.Events;

public class WeaponInputMiddleman : BaseToggleInputMiddleman, IWeapon
{
    public UnityEvent NextWeapon = new UnityEvent();
    public UnityEvent PreviousWeapon = new UnityEvent();
    public UnityEvent NextWeaponMode = new UnityEvent();
    public UnityEvent PreviousWeaponMode = new UnityEvent();

    public void Activate(bool status)
    {
        Notify(status);
    }

    public void Next()
    {
        NextWeapon.Invoke();
    }

    public void NextMode()
    {
        NextWeaponMode.Invoke();
    }

    public void Previous()
    {
        PreviousWeapon.Invoke();
    }

    public void PreviousMode()
    {
        PreviousWeaponMode.Invoke();
    }
}