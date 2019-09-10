using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sensor : MonoBehaviour, ISensor
{
    [SerializeField] private float interval = 0;

    public bool Active { get; protected set; }

    public event Action<GameObject> OnTargetDetected;
    public event Action<GameObject> OnTargetLost;

    private Coroutine coroutine = null;

    protected virtual void Awake() { }

    private void OnEnable()
    {
        coroutine = StartCoroutine(Scaning());
    }
    private void OnDisable()
    {
        if (coroutine != null) StopCoroutine(coroutine);
    }

    protected virtual IEnumerator Scaning()
    {
        while(true)
        {
            Active = Scan();
            yield return new WaitForSeconds(interval);
        }
    }

    protected abstract bool Scan();

    protected void TargetLost(GameObject gameObject)
    {
        OnTargetDetected?.Invoke(gameObject);
    }

    protected void TargetDetected(GameObject gameObject)
    {
        OnTargetLost?.Invoke(gameObject);
    }
}
