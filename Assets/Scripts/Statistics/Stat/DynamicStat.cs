using UnityEngine;
using UnityEngine.Events;

namespace Statistics
{
    [DisallowMultipleComponent]
    public class DynamicStat : MonoBehaviour, IDynamicStat
    {
        [SerializeField] private Type type = new Type();
        public string Name => type;

        [SerializeField] private Stat MaxStatValue = null;
        public float MaxValue { get => MaxStatValue != null ? MaxStatValue.Value : float.PositiveInfinity; }

        public float Value { get; private set; }

        [Space]
        [SerializeField] private UnityEvent onStatEmptyCallback = new UnityEvent();
        public UnityEvent OnStatEmptyCallback => onStatEmptyCallback;

        [SerializeField] private UnityEvent onStatFullCallback = new UnityEvent();
        public UnityEvent OnStatFullCallback => onStatFullCallback;

        [SerializeField] private OnStatUpdate onStatUpdateCallback = new OnStatUpdate();
        public OnStatUpdate OnStatUpdateCallback => onStatUpdateCallback;

        private void OnEnable()
        {
            Value = MaxStatValue != null ? MaxValue : float.NaN;
#if UNITY_EDITOR
            gameObject.name = string.Format("{0} is : {1}/{2}", Name, Value, MaxStatValue != null ? MaxValue.ToString("0.00") : "-/-");
#endif
        }

        private void OnValidate()
        {
            gameObject.name = string.Format("{0} is : {1}/{2}", Name, Value, MaxStatValue != null ? MaxValue.ToString("0.00") : "-/-");
        }

        public void UpdateValue(float value)
        {
            Value += value;
            if (Value <= 0)
                onStatEmptyCallback.Invoke();

            if (Value >= MaxValue)
            {
                Value = MaxValue;
                onStatFullCallback.Invoke();
            }

            OnStatUpdateCallback.Invoke(Value);

#if UNITY_EDITOR
            gameObject.name = string.Format("{0} is : {1}/{2}", Name, Value, MaxStatValue != null ? MaxValue.ToString("0.00") : "-/-");
            string color = value >= 0 ? "#008000ff" : "#a52a2aff", action = value >= 0 ? "increases" : "decreases";
            string log = string.Format("Stat {0} of {1} {2} its value by <color={3}>{4}</color>",
                Name,
                transform.root.name,
                action,
                color,
                Mathf.Abs(value));
            Debug.Log(log, transform.root);
#endif
        }
    }
}