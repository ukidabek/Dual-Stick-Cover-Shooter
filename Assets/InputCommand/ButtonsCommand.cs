using Commands;
using Player;
using System;

public class ButtonsCommand : Command
{
    private byte _playerID = 0;
    private byte _buttonsCount = 0;
    private ushort _inputs = 0;

    public ButtonsCommand(int playerID, byte buttonsCount, ushort inputs)
    {
        _playerID = (byte)playerID;
        _buttonsCount = buttonsCount;
        _inputs = inputs;
    }

    public override void Execute()
    {
        var buttonCommandReciver = PlayerController.Players[_playerID].GetComponentInChildren<ButtonCommandReciver>();
        for (int i = 0; i < _buttonsCount; i++)
            buttonCommandReciver.SetStatus(i, Convert.ToBoolean((_inputs >> i) & 1));
    }
}
