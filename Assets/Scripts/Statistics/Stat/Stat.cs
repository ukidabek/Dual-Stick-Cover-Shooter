using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Statistics
{
    [DisallowMultipleComponent]
    public class Stat : MonoBehaviour, IStat, IModifiableStat
    {
        [SerializeField] private string _name = string.Empty;
        public string Name => _name;

        [SerializeField] private float baseValue = 1f;
        private bool isDirty = true; 
        private float value = float.MinValue; 
        public float Value
        {
            get
            {
                if (isDirty) CalculateValue();
                return value;
            }
            private set { this.value = value; }
        }

        [SerializeField] private OnStatUpdate _onStatRecalculatedCallback = new OnStatUpdate();
        public OnStatUpdate OnStatRecalculatedCallback => _onStatRecalculatedCallback;

        private readonly List<StatModifier> statModifiers = new List<StatModifier>();
        public readonly ReadOnlyCollection<StatModifier> StatModifiers = null;

        private void Awake()
        {
#if UNITY_EDITOR
            gameObject.name = string.Format("{0} is : {1}", _name, Value);
#endif
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
#if UNITY_EDITOR
            gameObject.name = string.Format("{0} is : {1}", _name, Value);
#endif
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

        private void OnValidate()
        {
            gameObject.name = _name;
        }
    }
}
