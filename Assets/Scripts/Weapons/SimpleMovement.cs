using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    public float Speed { get => _speed; set => _speed = value; }

    private void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;    
    }
}
