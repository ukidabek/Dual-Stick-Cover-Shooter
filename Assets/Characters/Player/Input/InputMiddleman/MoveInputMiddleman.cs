using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputMiddleman : BaseVector3InputMiddleman, IMove
{
    public bool OnPosition
    {
        get
        {
            Debug.LogWarning("This property is not used by the player. Always retunr true.");
            return true;
        }
    }

    public void Set(Vector3 input)
    {
        Notify(input);
    }

    public void Stop()
    {
        Notify(Vector3.zero);
    }
}