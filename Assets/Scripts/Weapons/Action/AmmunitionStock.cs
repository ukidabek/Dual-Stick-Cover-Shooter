using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MagazineAction))]
public class AmmunitionStock : MonoBehaviour, IAmmunitionStock
{
    [SerializeField] private MagazineAction _magazine = null;
    [SerializeField] private int _counter = 0;
    public int Counter { get => _counter; }
    [SerializeField] private int _stock = 200;
    public int MaxSize { get => _stock; }
    [SerializeField] private bool _subscribeToEvents = false;

    public event Action OnEmpty;
    public event Action<int> OnChange;


    private void Awake()
    {
        if (_subscribeToEvents)
            _magazine.OnEmpty += OnEmptyCallback;
        _counter = _stock;
    }

    public void OnEmptyCallback()
    {
        int value = _magazine.MaxSize - _magazine.Counter;
        if (value < _counter)
        {
            _counter -= value;
            OnChange?.Invoke(_counter);
            _magazine.Reload();
        }
    }

    private void Reset()
    {
        _magazine = GetComponent<MagazineAction>();
    }
}
