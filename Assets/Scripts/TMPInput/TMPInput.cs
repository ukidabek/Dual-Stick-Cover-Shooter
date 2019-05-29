using Mechanic.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TMPInput : MonoBehaviour
{
    [Serializable]
    private class Trigger
    {
        [SerializeField] private string _anim = "Fire 1";
        private float currentValue = 0;
        private float newValue = 0;

        public UnityEvent onDown = new UnityEvent();
        public UnityEvent onHold = new UnityEvent();
        public UnityEvent onUp = new UnityEvent();

        public Trigger(string anim)
        {
            _anim = anim;
        }

        public void Validate()
        {
            newValue = Input.GetAxisRaw(_anim);
            if (newValue > 0f && currentValue == 0f)
                onDown.Invoke();
            if (newValue > 0f && currentValue > 0f)
                onHold.Invoke();
            if (newValue == 0 && currentValue > 0f)
                onUp.Invoke();
            currentValue = newValue;
        }

        public float Value { get { return Input.GetAxis(_anim); } }
    }

    [Serializable]
    private class ButtonHandler
    {
        [SerializeField] private KeyCode key = KeyCode.None;
        public UnityEvent onKeyDown = new UnityEvent();
        public UnityEvent onKeyUp = new UnityEvent();

        public void Validate()
        {
            if (Input.GetKeyDown(key))
                onKeyDown.Invoke();
            if (Input.GetKeyUp(key))
                onKeyUp.Invoke();
        }
    }

    public Vector3InputCallback movementCallback = new Vector3InputCallback();
    [SerializeField] private Vector3 _movementInput = Vector3.zero;

    public Vector3InputCallback lookCallback = new Vector3InputCallback();
    [SerializeField] private Vector3 _lookInput = Vector3.zero;

    [SerializeField] private string _horizontal = "Horizontal";
    [SerializeField] private string _vertical = "Vertical";
    [SerializeField] private string _lookHorizontal = "Mouse X";
    [SerializeField] private string _lookVertical = "Mouse Y";

    [SerializeField] private Trigger _aim = new Trigger("Fire1");
    [SerializeField] private Trigger _fire = new Trigger("Fire2");

    public Vector3InputCallback triggersCallback = new Vector3InputCallback();
    [SerializeField] private Vector3 _triggersInput = Vector3.zero;

    [SerializeField] private ButtonHandler _use = new ButtonHandler();

    void Update()
    {
        _movementInput.x = Input.GetAxis(_horizontal);
        _movementInput.z = Input.GetAxis(_vertical);
        _lookInput.x = Input.GetAxis(_lookHorizontal);
        _lookInput.z = Input.GetAxis(_lookVertical);
        _triggersInput.x = _aim.Value;
        _triggersInput.z = _fire.Value;
        _aim.Validate();
        _fire.Validate();
        _use.Validate();

        movementCallback.Invoke(_movementInput);
        lookCallback.Invoke(_lookInput);
        triggersCallback.Invoke(_triggersInput);
    }
}
