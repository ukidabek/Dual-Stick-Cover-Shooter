using UnityEngine.Events;

namespace Statistics
{
    public interface IDynamicStat : IStat
    {
        float MaxValue { get; }
        void UpdateValue(float value);
        UnityEvent OnStatEmptyCallback { get; }
        UnityEvent OnStatFullCallback { get; }
        OnStatUpdate OnStatUpdateCallback { get; }
    }
}
