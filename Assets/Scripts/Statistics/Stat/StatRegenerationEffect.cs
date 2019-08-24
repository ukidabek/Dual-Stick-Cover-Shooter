using UnityEngine;

namespace Statistics
{
    public class StatRegenerationEffect : DynamicStatEffect
    {
        [SerializeField] private float regenerationRate = 3;

        protected override void Awake()
        {
            base.Awake();
            enabled = false;
        }

        protected override void OnStatEmpty() {}

        protected override void OnStatFull()
        {
            enabled = false;
        }

        protected override void OnStatUpdate(float value)
        {
            enabled = dynamicStat.Value < dynamicStat.MaxValue;
        }

        private void Update()
        {
            dynamicStat.UpdateValue(regenerationRate * Time.deltaTime);
        }
    }
}