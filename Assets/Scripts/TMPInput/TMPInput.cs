using Mechanic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TMPInput : MonoBehaviour
{
    public Vector3InputCallback movementCallback = new Vector3InputCallback();
    [SerializeField] private Vector3 _movementInput = Vector3.zero;

    public Vector3InputCallback lookCallback = new Vector3InputCallback();
    [SerializeField] private Vector3 _lookInput = Vector3.zero;

    [SerializeField] private string _horizontal = "Horizontal";
    [SerializeField] private string _vertical = "Vertical";
    [SerializeField] private string _lookHorizontal = "Mouse X";
    [SerializeField] private string _lookVertical = "Mouse Y";
    [SerializeField] private string _anim = "Fire 1";
    private float currentValue = 0;
    private float newValue = 0;

    public UnityEvent onAimDown = new UnityEvent();
    public UnityEvent onAimUp = new UnityEvent();

    void Update()
    {
        _movementInput.x = Input.GetAxis(_horizontal);
        _movementInput.z = Input.GetAxis(_vertical);
        _lookInput.x = Input.GetAxis(_lookHorizontal);
        _lookInput.z = Input.GetAxis(_lookVertical);

        newValue = Input.GetAxisRaw(_anim);
        if (newValue > 0f && currentValue == 0f)
            onAimDown.Invoke();
        if (newValue == 0 && currentValue > 0f)
            onAimUp.Invoke();

        currentValue = newValue;

        movementCallback.Invoke(_movementInput);
        lookCallback.Invoke(_lookInput);
    }
}
