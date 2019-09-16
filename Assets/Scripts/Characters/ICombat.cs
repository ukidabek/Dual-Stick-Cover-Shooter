using UnityEngine;

public interface ICombat
{
    bool HasWeapon { get; }
    float Range { get; }
    void Attack(GameObject target = null);
}
