using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Weapons;

public class MagazineAction : WeaponAction
{
    [SerializeField] private int _maxSize = 7;
    [SerializeField] private int _counter = 0;

    public UnityEvent OnEmptyCallback = new UnityEvent();

    private void Awake()
    {
        _counter = _maxSize;
    }

    public override bool Perform()
    {
        if(--_counter == 0)
        {
            _counter = _maxSize;
            OnEmptyCallback.Invoke();
            return false;
        }

        return true;
    }
}
