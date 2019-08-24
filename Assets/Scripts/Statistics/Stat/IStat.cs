using UnityEngine.Events;

namespace Statistics
{
    public interface IStat
    {
        string Name { get; }
        float Value { get; }
    }

    public interface IModifiableStat : IStat
    {
        void AddModifier(StatModifier modifier);
        void RemoveModifier(StatModifier modifier);
        void RemoveAllModifierFrom(object source);
        OnStatUpdate OnStatRecalculatedCallback { get; }
    }

    public interface IDynamicStat : IStat
    {
        float MaxValue { get; }
        void UpdateValue(float value);
        UnityEvent OnStatEmptyCallback { get; }
        UnityEvent OnStatFullCallback { get; }
        OnStatUpdate OnStatUpdateCallback { get; }
    }
}
