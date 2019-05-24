using UnityEngine;
using System;

[Serializable]
public class RotationSnap
{
    [SerializeField] private bool _instantRotationSnap = true;
    [SerializeField] private float _rotationSnapSpeed = 10f;

    public Quaternion GetRotation(Quaternion current, Quaternion target)
    {
        if (_instantRotationSnap)
            return target;
        else
            return Quaternion.RotateTowards(current, target, _rotationSnapSpeed);
    }
} 