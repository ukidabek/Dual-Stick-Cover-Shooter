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

        private IModifiableStat GetStat(GameObject gameObject)
        {
            var status = gameObject.GetComponentsInChildren<IModifiableStat>();
            foreach (var item in status)
                if (item.Name == statName)
                    return item;
            return null;
        }

        public void ApplayTo(GameObject gameObject)
        {
            IModifiableStat modifiableStat = GetStat(gameObject);
            if (modifiableStat != null)
            {
#if UNITY_EDITOR
                string logColor = value == 0 ? "#ffff00ff" : value > 0 ? "#008000ff" : "#a52a2aff";
                Debug.LogFormat("<color={2}>{0} stat modyfier of value {3} applayed for {1}</color>.", statName, gameObject.name, logColor, value);
#endif
                modifiableStat.AddModifier(new StatModifier(value, mode, this));
            }
        }

        public void RemoveForm(GameObject gameObject)
        {
            IModifiableStat modifiableStat = GetStat(gameObject);
            if (modifiableStat != null)
            {
#if UNITY_EDITOR
                string logColor = value == 0 ? "#ffff00ff" : value < 0 ? "#008000ff" : "#a52a2aff";
                Debug.LogFormat("<color={2}>{0} stat modyfier of value {3} removed for {1}</color>.", statName, gameObject.name, logColor, value);
#endif
                modifiableStat.RemoveAllModifierFrom(this);
            }

        }
    }
}