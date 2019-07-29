using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Statistics
{
    public class StatMomoBehavior : MonoBehaviour, IStat
    {
        [SerializeField] private Stat stat = new Stat();

        public float Value => stat.Value;

        public OnStatRecalculated OnStatRecalculatedCallback => stat.OnStatRecalculatedCallback;

        public string Name => stat.Name;

        public event Action<float> OnStatChanged;

        private void Awake()
        {
            stat.OnStatRecalculatedCallback.Invoke(stat.Value);
        }

        public void AddModifier(StatModifier modifier)
        {
            stat.AddModifier(modifier);
        }

        public void RemoveModifier(StatModifier modifier)
        {
            stat.RemoveModifier(modifier);
        }

        public void RemoveAllModifierFrom(object source)
        {
            stat.RemoveAllModifierFrom(source);
        }
    }
}