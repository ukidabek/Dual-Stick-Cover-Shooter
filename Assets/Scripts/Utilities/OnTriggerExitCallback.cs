using UnityEngine;

public class OnTriggerExitCallback : OnTriggerCallback
{
    private void OnTriggerExit(Collider other)
    {
        OnColliderCallback.Invoke(other);
        OnGameObjectCallback.Invoke(other.gameObject);
    }
}