using UnityEngine;

namespace Weapons
{
    public class HitHandler : MonoBehaviour, IHit
    {
        public OnDealDamage OnDealDamage = new OnDealDamage();

        public void DealDamage(float damage)
        {
            OnDealDamage.Invoke(damage);
        }
    }
}

