using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class CollisionCallback : UnityEvent<Collision> { }

public class OnCollisionEnterCallback : MonoBehaviour
{
    public CollisionCallback Callback = new CollisionCallback();

    private void OnCollisionEnter(Collision collision)
    {
        Callback.Invoke(collision);
    }
}
