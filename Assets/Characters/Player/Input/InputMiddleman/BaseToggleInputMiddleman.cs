using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseToggleInputMiddleman : MonoBehaviour
{
    public BoolInputCallback InputCallback = new BoolInputCallback();

    public void Notify(bool status)
    {
        InputCallback.Invoke(status);
    }
}