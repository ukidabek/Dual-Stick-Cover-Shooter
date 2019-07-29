using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Statistics
{
    [Serializable]
    public class Stat : IStat
    {
        [SerializeField] private string _name = string.Empty;
        public string Name => _name;

        [SerializeField] private float baseValue = 1f;
        private bool isDirty = true; 
        [SerializeField] private float value = float.MinValue; 
        public float Value
        {
            get
            {
                if (isDirty) { CalculateValue(); }
                return value;
            }
            private set { this.value = value; }
        }

        [SerializeField] private OnStatRecalculated _onStatRecalculatedCallback = new OnStatRecalculated();
        public OnStatRecalculated OnStatRecalculatedCallback => _onStatRecalculatedCallback;

        private readonly List<StatModifier> statModifiers = new List<StatModifier>();

        public Stat() : this(1) { }

        public Stat(float baseValue)
        {
            Value = this.baseValue = baseValue;
        }

        public static implicit operator float(Stat stat)
        {
            return stat.Value;
        }

        public void AddModifier(StatModifier modifier)
        {
            statModifiers.Add(modifier);
            statModifiers.Sort();
            CalculateValue();
        }

        private void CalculateValue()
        {
            isDirty = false;
            float stack = 0;
            Value = baseValue;
            foreach (var item in statModifiers)
            {
                switch (item.Mode)
                {
                    case StatModifier.ModifierMode.Float:
                        Value += item.Value;
                        break;
                    case StatModifier.ModifierMode.Percent:
                        Value *= (1 + item.Value);
                        break;
                    case StatModifier.ModifierMode.Stack:
                        stack += item.Value;
                        break;
                }
            }
            Value *= (1 + stack);
            Value = (float)Math.Round(Value, 4);
            OnStatRecalculatedCallback.Invoke(this);
        }

        public void RemoveModifier(StatModifier modifier)
        {
            for (int i = statModifiers.Count - 1; i >= 0; i--)
                if (statModifiers[i] == modifier)
                    statModifiers.RemoveAt(i);
            CalculateValue();
        }

        public void RemoveAllModifierFrom(object source)
        {
            for (int i = statModifiers.Count -1; i >=0 ; i--)
                if (statModifiers[i].Source == source)
                    statModifiers.RemoveAt(i);
            CalculateValue();
        }
    }
}
