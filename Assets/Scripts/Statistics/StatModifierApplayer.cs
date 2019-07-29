using System;
using UnityEngine;
using UnityEngine.Events;

namespace Statistics
{
    public class StatModifierApplayer : MonoBehaviour
    {
        [SerializeField] private string statName = string.Empty;
        [SerializeField] private float value = 1f;
        [SerializeField] private StatModifier.ModifierMode mode = StatModifier.ModifierMode.Percent;

        private IStat GetStat(GameObject gameObject)
        {
            var status = gameObject.GetComponentsInChildren<IStat>();
            foreach (var item in status)
                if(item.Name == statName)
                    return item;
            return null;
        }

        public void ApplayTo(GameObject gameObject)
        {
            GetStat(gameObject)?.AddModifier(new StatModifier(value, mode, this));
        }

        public void RemoveForm(GameObject gameObject)
        {
            GetStat(gameObject)?.RemoveAllModifierFrom(this);
        }
    }
}