public interface ICombat
{
    bool HasWeapon { get; }
    float Range { get; }

    void Attack();
}
