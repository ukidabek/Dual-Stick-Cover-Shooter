using System;

public interface ICounter
{
    int Counter { get; }
    int MaxSize { get; }
    event Action OnEmpty;
    event Action<int> OnChange;
}
