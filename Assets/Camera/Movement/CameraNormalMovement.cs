using Mechanic.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNormalMovement : BaseMechanic
{
    [SerializeField] private Vector3 _offset = new Vector3(0f, 3f, 0f);
    [SerializeField] private Transform _transformToFollow = null;
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        transform.root.position = Vector3.MoveTowards(transform.root.position, _transformToFollow.position + _offset, _speed * Time.deltaTime);
    }
}
