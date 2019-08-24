using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class HitInvoker : MonoBehaviour
    {
        public float Damage = 10;

        private void OnCollisionEnter(Collision collision)
        {
            IHit hit = collision.gameObject.GetComponent<IHit>();
            if (hit != null)
                hit.DealDamage(Damage);
        }
    }
}