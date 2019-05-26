using Mechanic.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraTargetPositionProvider
{
    Vector3 TargetPosition { get; }
}

public class CameraNormalMovement : BaseMechanic
{
    [SerializeField] private Vector3 _offset = new Vector3(0f, 3f, 0f);
    [SerializeField] private float _speed = 5f;

    private ICameraTargetPositionProvider TargetPositionProvider = null;

    protected override void Awake()
    {
        base.Awake();
        TargetPositionProvider = gameObject.GetComponent<ICameraTargetPositionProvider>();
    }

    private void LateUpdate()
    {
        transform.root.position = Vector3.MoveTowards(transform.root.position, TargetPositionProvider.TargetPosition + _offset, _speed * Time.deltaTime);
    }
}
