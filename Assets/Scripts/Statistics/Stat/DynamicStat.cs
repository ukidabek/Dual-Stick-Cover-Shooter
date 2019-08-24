using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Statistics
{
    [DisallowMultipleComponent]
    public class DynamicStat : MonoBehaviour, IDynamicStat
    {
        [SerializeField] private string _name = "DynamicStat";
        public string Name => _name;

        [SerializeField] private Stat MaxStatValue = null;
        public float MaxValue { get =>  MaxStatValue != null ? MaxStatValue.Value : float.PositiveInfinity; }

        public float Value { get; private set; }

        [Space]
        [SerializeField] private UnityEvent onStatEmptyCallback = new UnityEvent();
        public UnityEvent OnStatEmptyCallback => onStatEmptyCallback;

        [SerializeField] private UnityEvent onStatFullCallback = new UnityEvent();
        public UnityEvent OnStatFullCallback => onStatFullCallback;

        [SerializeField] private OnStatUpdate onStatUpdateCallback = new OnStatUpdate();
        public OnStatUpdate OnStatUpdateCallback => onStatUpdateCallback;

        private void Awake()
        {
            Value = MaxStatValue != null ? MaxValue : float.NaN;
#if UNITY_EDITOR
            gameObject.name = string.Format("{0} is : {1}/{2}", _name, Value, MaxStatValue != null ? MaxValue.ToString("0.00") : "-/-");
#endif
        }

        private void OnValidate()
        {
            gameObject.name = string.Format("{0} is : {1}/{2}", _name, Value, MaxStatValue != null ? MaxValue.ToString("0.00") : "-/-");
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
            gameObject.name = string.Format("{0} is : {1}/{2}", _name, Value, MaxStatValue != null ? MaxValue.ToString("0.00") : "-/-");
#endif
        }
    }
}