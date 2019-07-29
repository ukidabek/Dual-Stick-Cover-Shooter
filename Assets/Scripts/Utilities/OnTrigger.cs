using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class OnColliderCallback : UnityEvent<Collider> { }
[Serializable] public class OnGameObjectCallback : UnityEvent<GameObject> { }

public abstract class OnTrigger : MonoBehaviour
{
    public OnColliderCallback OnColliderCallback = new OnColliderCallback();
    public OnGameObjectCallback OnGameObjectCallback = new OnGameObjectCallback();
}
