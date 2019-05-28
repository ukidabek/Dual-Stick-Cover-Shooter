using Mechanic.Utilities;
using System.Collections;
using UnityEngine;

public class AnalogInputStatusReciver : MonoBehaviour
{
    public Vector3InputCallback InputCallback = new Vector3InputCallback();

    public void SetStatus(Vector3 input)
    {
        InputCallback.Invoke(input);
    }
} 
