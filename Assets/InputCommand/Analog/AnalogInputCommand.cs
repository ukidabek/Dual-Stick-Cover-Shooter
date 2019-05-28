using Commands;
using Player;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnalogInputCommand : Command
{
    private byte _playerID = 0;
    private ushort[] _inputs = null;

    public AnalogInputCommand(int playerID, List<AnalogInputStatus> movement)
    {
        _playerID = (byte)playerID;

        _inputs = new ushort[movement.Count];
        for (int i = 0; i < movement.Count; i++)
            _inputs[i] = ConvertToBytes(movement[i]);
    }

    public override void Execute()
    {
        var analogInputCommandReciver = PlayerController.Players[_playerID].GetComponentInChildren<AnalogInputCommandReciver>();
        for (int i = 0; i < _inputs.Length; i++)
            analogInputCommandReciver.SetInput(i, ConvertToVector3(_inputs[i]));
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
