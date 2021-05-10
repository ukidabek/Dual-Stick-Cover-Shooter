using System;
using UnityEngine;
using UnityEngine.Events;
using Weapons;

[Serializable] public class OnMagazineCounterChangeEvent : UnityEvent<int> { }

public class MagazineAction : WeaponAction, IMagazine
{
    [SerializeField] private int _maxSize = 7;
    public int MaxSize => _maxSize;

    [SerializeField] private int _counter = 0;
    public int Counter => _counter;

    public UnityEvent OnEmptyCallback = new UnityEvent();
    public OnMagazineCounterChangeEvent OnMagazineCounterChangeCallback = new OnMagazineCounterChangeEvent();

    public event Action OnEmpty;
    public event Action<int> OnChange;

    private void Awake()
    {
        OnEmptyCallback.AddListener(() => OnEmpty?.Invoke());
        OnMagazineCounterChangeCallback.AddListener((int counter) => OnChange?.Invoke(counter));
        OnMagazineCounterChangeCallback.Invoke(_counter = _maxSize);
    }

    public override void Perform(GameObject user, GameObject target)
    {
        OnMagazineCounterChangeCallback.Invoke(--_counter);
        if (_counter == 0)
            OnEmptyCallback.Invoke();
    }

    public void Reload()
    {
        _counter = _maxSize;
        OnMagazineCounterChangeCallback.Invoke(_counter);
    }
}
