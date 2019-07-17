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
    public int Stock { get => _stock; }
    [SerializeField] private bool _subscribeToEnents = false;

    public event Action<int> OnStackChange;

    private void Awake()
    {
        if (_subscribeToEnents)
            _magazine.OnEmpty += OnEmpty;
        _counter = _stock;
    }

    public void OnEmpty()
    {
        int value = _magazine.MaxSize - _magazine.Counter;
        if (value < _counter)
        {
            _counter -= value;
            OnStackChange?.Invoke(_counter);
            _magazine.Reload();
        }
    }

    private void Reset()
    {
        _magazine = GetComponent<MagazineAction>();
    }
}
