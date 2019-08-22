using Mechanic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseVector3InputMiddleman : MonoBehaviour
{
    public Vector3InputCallback InputCallback = new Vector3InputCallback();
    
    protected void Notify(Vector3 input)
    {
        InputCallback.Invoke(input);
    }
}
