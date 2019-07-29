using UnityEngine;

public class OnTriggerExitCallback : OnTrigger
{
    private void OnTriggerExit(Collider other)
    {
        OnColliderCallback.Invoke(other);
        OnGameObjectCallback.Invoke(other.gameObject);
    }
}