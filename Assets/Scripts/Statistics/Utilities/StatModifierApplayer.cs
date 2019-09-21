using UnityEngine;

namespace Statistics
{
    public class StatModifierApplayer : MonoBehaviour
    {
        [SerializeField] private Type statToMofifyType = new Type();
        [SerializeField] private float value = 1f;
        [SerializeField] private StatModifier.ModifierMode mode = StatModifier.ModifierMode.Percent;

        private IModifiableStat GetStat(GameObject gameObject)
        {
            var status = gameObject.GetComponentInChildren<Stats>();
            return status != null ? status.GetModifiableStat(statToMofifyType) : null;
        }

        public void ApplayTo(GameObject gameObject)
        {
            IModifiableStat modifiableStat = GetStat(gameObject);
            if (modifiableStat != null)
            {
#if UNITY_EDITOR
                string logColor = value == 0 ? "#ffff00ff" : value > 0 ? "#008000ff" : "#a52a2aff";
                Debug.LogFormat("<color={2}>{0} stat modifier of value {3} apply for {1}</color>.", statToMofifyType, gameObject.name, logColor, value);
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
                Debug.LogFormat("<color={2}>{0} stat modifier of value {3} removed for {1}</color>.", statToMofifyType, gameObject.name, logColor, value);
#endif
                modifiableStat.RemoveAllModifierFrom(this);
            }

        }
    }
}