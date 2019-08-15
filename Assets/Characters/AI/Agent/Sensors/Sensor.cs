using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    [SerializeField] private float interval = 0;

    public bool Active { get; protected set; }

    protected virtual void Awake()
    {
        StartCoroutine(Scaning());
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
}
