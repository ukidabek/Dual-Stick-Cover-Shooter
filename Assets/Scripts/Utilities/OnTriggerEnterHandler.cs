using UnityEngine;

public class OnTriggerEnterHandler : OnTrigger
{
    private void OnTriggerEnter(Collider other)
    {
        OnColliderCallback.Invoke(other);
        OnGameObjectCallback.Invoke(other.gameObject);
    }
}
