using UnityEngine;
using Mechanic.BaseClasses;
using Player;

namespace Player.Aim
{
    public class AimController : BaseMechanic, IAim
    {
        [Tooltip("Transform to ratate when aiming.")]
        [SerializeField] private Transform _transform = null;
        [SerializeField] private Vector3 _input = Vector3.zero;
        public Vector3 MoveInput { get => _input; set => _input = value; }

        [SerializeField] private RotationSnap rotationSnap = new RotationSnap();

        private void Update()
        {
            if (_input.magnitude > 0.1f)
                _transform.rotation = rotationSnap.GetRotation(_transform.rotation, Quaternion.LookRotation(_input));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(_transform.position, _transform.forward * .25f);
        }
    }
}