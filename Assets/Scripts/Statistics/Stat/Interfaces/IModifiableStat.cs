namespace Statistics
{
    public interface IModifiableStat : IStat
    {
        void AddModifier(StatModifier modifier);
        void RemoveModifier(StatModifier modifier);
        void RemoveAllModifierFrom(object source);
        OnStatUpdate OnStatRecalculatedCallback { get; }
    }
}
