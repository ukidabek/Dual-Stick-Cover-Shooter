using UnityEngine;
using Mechanic.BaseClasses;

namespace Player.Movement
{
    public class TransformLocalRotationReset : BaseMechanic
    {
        [SerializeField] private Transform _transform = null;
        [SerializeField] private float _restoreSpeed = 10f;

        private void Update()
        {
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _transform.root.rotation, _restoreSpeed);
            if (_transform.rotation == _transform.root.rotation)
                enabled = false;
        }
    }
}