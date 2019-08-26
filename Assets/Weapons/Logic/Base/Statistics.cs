using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class Statistics
    {
        [SerializeField] private float _damage = 10f;
        public float Damage { get => _damage; }

        [SerializeField] private float _range = 30f;
        public float Range { get => _range; }
    }
}