public interface IWeaponEquipment : IEquipment
{
    object CurrentWeapon { get; }
    void Next();
    void Previous();
    void Select(int index);
}
