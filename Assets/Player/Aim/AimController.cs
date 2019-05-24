using UnityEngine;
using Mechanic.BaseClasses;

public class AimController : MechanicWithSettings<AimControllerSettings>
{
    [SerializeField] private Transform _transform = null;
    [SerializeField] private Vector3 _input = Vector3.zero;
    public Vector3 Input { get => _input; set => _input = value; }

    [SerializeField] private RotationSnap rotationSnap = new RotationSnap();

    private void Update()
    {
        if (_input.magnitude > 0.1f)
            _transform.rotation = rotationSnap.GetRotation(_transform.rotation, Quaternion.LookRotation(_input));
    }
}
