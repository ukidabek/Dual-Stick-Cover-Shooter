using UnityEngine;
using UnityEngine.Events;

public abstract class BaseInputMiddleman : MonoBehaviour
{
    public UnityEvent InputCallback = new UnityEvent();

    protected void Notify()
    {
        InputCallback.Invoke();
    }
}
