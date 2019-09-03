using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDeactivator : MonoBehaviour
{
    [SerializeField] private float _timeToDeactivate = 5f;
    private float _counter = 0;

    public void OnEnable()
    {
        _counter = _timeToDeactivate;    
    }

    private void Update()
    {
        if ((_counter -= Time.deltaTime) <= 0)
            gameObject.SetActive(false);
    }
}
