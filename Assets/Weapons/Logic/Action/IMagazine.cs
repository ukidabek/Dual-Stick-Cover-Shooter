using System;
using UnityEngine.Events;

public interface IMagazine
{
    int Counter { get; }
    int MaxSize { get; }
    event Action OnEmpty;
    event Action<int> OnCounterChange;
}