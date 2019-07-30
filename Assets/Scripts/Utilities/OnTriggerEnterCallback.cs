using UnityEngine;

public class OnTriggerEnterCallback : OnTriggerCallback
{
    private void OnTriggerEnter(Collider other)
    {
        OnColliderCallback.Invoke(other);
        OnGameObjectCallback.Invoke(other.gameObject);
    }
}
