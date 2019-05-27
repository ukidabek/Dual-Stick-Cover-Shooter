using Commands;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MovementCommand : Command
{
    private byte _playerID = 0;
    private int _movementAndAim = 0;
    private ushort _triggers = 0;

    public Vector3 Movement { get => ConvertToVector3(_movementAndAim, 16); }
    public Vector3 Aim { get => ConvertToVector3(_movementAndAim); }

    public float LeftTrigger { get => ConvertToFloat(_triggers, 8); }
    public float RightTrigger { get => ConvertToFloat(_triggers); }

    public MovementCommand(int playerID, Vector3 movement, Vector3 aim, Vector3 triggers)
    {
        _playerID = (byte)playerID;
        _movementAndAim = ConvertToBytes(movement) << 16 | ConvertToBytes(aim);
        _triggers = ConvertToBytes(triggers);
    }

    public override void Execute()
    {
        PlayerController.Players[_playerID].Move(Movement);
        PlayerController.Players[_playerID].Aim(Aim);
    }

    private byte ConvertToByte(float value)
    {
        return (byte)(value * 124);
    }

    private ushort ConvertToBytes(Vector3 input)
    {
        byte horizontal = ConvertToByte(input.x);
        byte vertical = ConvertToByte(input.z);
        return (ushort)((horizontal << 8) | vertical);
    }

    private float ConvertToFloat(ushort value, byte shift = 0)
    {
        return (sbyte)((value >> shift) & 255) / 124f;
    }

    private Vector3 ConvertToVector3(int input, byte shift = 0)
    {
        return ConvertToVector3((ushort)(input >> shift));
    }

    private Vector3 ConvertToVector3(ushort input)
    {
        return new Vector3(ConvertToFloat(input, 8), 0, ConvertToFloat(input));
    }
}

public class MovementCommandInvoker : CommandInvoker
{
    [Serializable]
    public class AnalogInputHandler
    {
        [SerializeField] private Vector3 _input = Vector3.zero;
        public Vector3 Input
        {
            get
            {
                _isDirty = false;
                return _input;
            }
            set => _isDirty = ValidateVector(ref _input, value);
        }

        [SerializeField] private bool _isDirty = true;
        public bool IsDirty { get => _isDirty; }
        private bool ValidateVector(ref Vector3 current, Vector3 input)
        {
            if (current != input)
            {
                current = input;
                return true;
            }
            return false;
        }

        public static implicit operator Vector3(AnalogInputHandler inputHandler)
        {
            return inputHandler.Input;
        }
    }

    [SerializeField] private byte _playerID = 0;
    public byte PlayerID { get => _playerID; set => _playerID = value; }

    [SerializeField] private AnalogInputHandler _movementInput = new AnalogInputHandler();
    public Vector3 MovementInput
    {
        get => _movementInput.Input;
        set => _movementInput.Input = value;
    }


    [SerializeField] private AnalogInputHandler _aimInput = new AnalogInputHandler();
    public Vector3 AimInput
    {
        get => _aimInput.Input;
        set => _aimInput.Input = value;
    }

    [SerializeField] private AnalogInputHandler _triggersInput = new AnalogInputHandler();
    public Vector3 TriggersInput
    {
        get => _triggersInput.Input;
        set => _triggersInput.Input = value;
    }


    protected override Command Command
    {
        get
        {
            if (_movementInput.IsDirty || _aimInput.IsDirty || _triggersInput.IsDirty)
                return new MovementCommand(_playerID, _movementInput, _aimInput, _triggersInput);

            return null;
        }
    }


    private bool ValidateVector(ref Vector3 current, Vector3 input)
    {
        if (current != input)
        {
            current = input;
            return true;
        }
        return false;
    }

    private void Update()
    {
        Invoke();
    }
}
