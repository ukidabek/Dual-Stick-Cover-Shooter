using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRate : WeaponValidator
{
    [SerializeField] private float _rate = 1f;
    [SerializeField] private float _counter = 0f;

    private void Awake()
    {
        _counter = 0;
    }

    public override bool Validate()
    {
        if (!enabled) return enabled = true;
        return false;
    }

    private void Update()
    {
        _counter -= Time.deltaTime;
        if (_counter <= 0)
        {
            _counter = _rate;
            enabled = false;
        }
    }
}
