using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class ToggleStatusCallback : UnityEvent<bool> { }

public class ToggleController : MonoBehaviour
{
    [SerializeField] private bool _status;

    public ToggleStatusCallback ToggleStatus = new ToggleStatusCallback();

    private void Awake()
    {
        ToggleStatus.Invoke(_status);
    }

    public void Toggle()
    {
        ToggleStatus.Invoke(_status = !_status);
    }
}
