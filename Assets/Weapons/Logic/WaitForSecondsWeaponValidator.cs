using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class WaitForSecondsWeaponValidator : WeaponValidator
{
    [SerializeField] private float _timeToWait = 1f;
    [SerializeField] private float _counter = 0;

    private void Awake()
    {
        enabled = false;
    }

    public override bool Validate()
    {
        return _counter <= 0;
    }

    private void OnEnable()
    {
        _counter = _timeToWait;
    }

    private void Update()
    {
        _counter -= Time.deltaTime;
        if (_counter <= 0) enabled = false;
    }
}
