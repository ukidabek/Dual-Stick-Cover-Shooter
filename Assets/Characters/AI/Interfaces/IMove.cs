using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    bool OnPosition { get; }
    void Move(Vector3 position);
}
