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

	private Vector3 _targetPosition = Vector3.zero;
	private float _distance;

	protected override void Awake()
    {
        base.Awake();
        TargetPositionProvider = gameObject.GetComponent<ICameraTargetPositionProvider>();
    }

    private void LateUpdate()
    {
		_targetPosition = TargetPositionProvider.TargetPosition + _offset;
		_distance = Vector2.Distance(transform.root.position, _targetPosition);

		if (_distance > _offset.magnitude)
			transform.root.position = _targetPosition;

		transform.root.position = Vector3.MoveTowards(transform.root.position, _targetPosition, _speed * Time.deltaTime);
    }
}
