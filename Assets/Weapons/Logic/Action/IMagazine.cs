using System;

public interface IMagazine
{
    int Counter { get; }
    int MaxSize { get; }
    event Action OnEmpty;
    event Action<int> OnCounterChange;
}