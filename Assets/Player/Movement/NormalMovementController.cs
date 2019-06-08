using UnityEngine;
using Mechanic.BaseClasses;
using Player;

namespace Player.Movement
{
    public class NormalMovementController : BaseMechanic, IMove
    {
        [SerializeField] private Vector3 _input = Vector3.zero;
        public Vector3 MoveInput { get => _input; set => _input = value; }

        [SerializeField] private Rigidbody _rigidbody = null;

        [Space]
        [SerializeField] private float _speed = 1f;
        [SerializeField] private RotationSnap rotationSnap = new RotationSnap();
        private Quaternion _targetRotation = Quaternion.identity;

        private void FixedUpdate()
        {
            if (_input.magnitude > 0)
            {
                _targetRotation = Quaternion.LookRotation(_input, Vector3.up);
                _rigidbody.rotation = rotationSnap.GetRotation(_rigidbody.rotation, _targetRotation);
            }

            _rigidbody.velocity = _rigidbody.transform.forward * Mathf.Abs(transform.InverseTransformDirection(_input).z) * _speed;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(_rigidbody.position, _input * .75f);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_rigidbody.position, _rigidbody.transform.forward * .5f);
        }
    }
}