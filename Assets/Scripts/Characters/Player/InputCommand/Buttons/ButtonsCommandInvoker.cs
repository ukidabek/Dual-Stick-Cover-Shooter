﻿using Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsCommandInvoker : CommandInvoker, IPlayerIDSetter
{
    public int PlayerID { get; set; }

    [SerializeField] private List<ButtonState> _buttonStates = new List<ButtonState>();
    [SerializeField] private ushort inputs = 0;
    [SerializeField] private ushort oldInputs = 0;

    protected override Command Command => new ButtonsCommand(PlayerID, (byte)_buttonStates.Count, inputs);

#if UNITY_EDITOR
    private string _defaultName = string.Empty;

    private void Awake()
    {
        _defaultName = gameObject.name;
    }
#endif

    private void Update()
    {
        inputs = 0;
        for (int i = 0; i < _buttonStates.Count; i++)
        {
            ushort status = Convert.ToUInt16(_buttonStates[i].Status);
            inputs = (ushort)(inputs | status << i);
        }
        if (inputs != oldInputs)
        {
            Invoke();
            oldInputs = inputs;
        }

#if UNITY_EDITOR
        gameObject.name = string.Format("{0} {1}", _defaultName, Convert.ToString(inputs,2).PadLeft(16,'0'));
#endif
    }
}
