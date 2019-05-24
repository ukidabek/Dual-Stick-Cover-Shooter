using UnityEngine;
using Mechanic.BaseClasses;

public class NormalMovementController : BaseMechanic
{
    [SerializeField] private Vector3 _input = Vector3.zero;
    public Vector3 Input { get => _input; set => _input = value; }

    [SerializeField] private Rigidbody _rigidbody = null;

    [Space]
    [SerializeField] private float _speed = 1f;
    [SerializeField] private RotationSnap rotationSnap = new RotationSnap();

    private void FixedUpdate()
    {
        if (_input.magnitude > 0)
            _rigidbody.rotation = rotationSnap.GetRotation(_rigidbody.rotation, Quaternion.LookRotation(_input, Vector3.up));

        _rigidbody.velocity = _rigidbody.transform.forward * Mathf.Abs(transform.InverseTransformDirection(_input.normalized).z) * _speed;
    }
}