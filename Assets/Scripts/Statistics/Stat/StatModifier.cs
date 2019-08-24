using System;

namespace Statistics
{
    [Serializable]
    public class StatModifier : IComparable<StatModifier>
    {
        public enum ModifierMode
        {
            Float = 100,
            Stack = 200,
            Percent = 300
        }

        public readonly float Value = 0;
        public readonly ModifierMode Mode = ModifierMode.Float;
        public readonly int Order = 0;
        public readonly object Source = null;

        public StatModifier(float value, ModifierMode mode, object source) : this(value, mode, (int)mode, source) { }

        public StatModifier(float value, ModifierMode mode) : this(value, mode, (int)mode, null) { }

        public StatModifier(float value, ModifierMode mode, int order, object source)
        {
            Value = value;
            Mode = mode;
            Order = order;
            Source = source;
        }

        public int CompareTo(StatModifier other)
        {
            if (Order < other.Order)
                return -1;
            else if (Order > other.Order)
                return 1;
            return 0;
        }
    }
}
