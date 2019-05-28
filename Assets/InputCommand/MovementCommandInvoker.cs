using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementCommandInvoker : CommandInvoker, IPlayerIDSetter
{
    public int PlayerID { get; set; }

    [SerializeField] private List<AnalogInputStatus> _analogInputStatuses = new List<AnalogInputStatus>();

    protected override Command Command
    {
        get
        {
            for (int i = 0; i < _analogInputStatuses.Count; i++)
                if (_analogInputStatuses[i].IsDirty)
                    return new MovementCommand(PlayerID, _analogInputStatuses);

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
