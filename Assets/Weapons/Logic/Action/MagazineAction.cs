using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Weapons;

[Serializable] public class OnMagazinecounterChangeEvent : UnityEvent<int> { }

public class MagazineAction : WeaponAction, IMagazine
{
    [SerializeField] private int _maxSize = 7;
    public int MaxSize { get => _maxSize; }

    [SerializeField] private int _counter = 0;
    public int Counter { get => _counter; }

    public UnityEvent OnEmptyCallback = new UnityEvent();
    public OnMagazinecounterChangeEvent OnMagazineCounterChangeCallback = new OnMagazinecounterChangeEvent();

    public event Action OnEmpty;
    public event Action<int> OnCounterChange;

    private void Awake()
    {
        _counter = _maxSize;
        OnEmptyCallback.AddListener(() => OnEmpty?.Invoke());
        OnMagazineCounterChangeCallback.AddListener((int counter) => OnCounterChange?.Invoke(counter));
    }

    public override bool Perform()
    {
        if (--_counter == 0)
        {
            Reload();
            OnEmptyCallback.Invoke();
            return false;
        }
        OnMagazineCounterChangeCallback.Invoke(_counter);
        return true;
    }

    private void Reload()
    {
        _counter = _maxSize;
        OnMagazineCounterChangeCallback.Invoke(_counter);
    }
}
