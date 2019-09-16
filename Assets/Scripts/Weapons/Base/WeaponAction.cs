using UnityEngine;

namespace Weapons
{
    public abstract class WeaponAction : MonoBehaviour
    {
        public abstract void Perform(GameObject user, GameObject target);
    }
}