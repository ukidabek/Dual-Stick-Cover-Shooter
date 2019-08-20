using System;
using UnityEngine;

public interface ISensor
{
    event Action<GameObject> OnTargetDetected;
    event Action<GameObject> OnTargetLost;
}
