namespace Statistics
{
    public interface IStat
    {
        string Name { get; }
        float Value { get; }
        void AddModifier(StatModifier modifier);
        void RemoveModifier(StatModifier modifier);
        void RemoveAllModifierFrom(object source);
        OnStatRecalculated OnStatRecalculatedCallback { get; }
    }
}
