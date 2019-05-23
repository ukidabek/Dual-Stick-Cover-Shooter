using UnityEngine;
using Mechanic.BaseClasses;

public class AimController : MechanicWithSettings<AimControllerSettings>
{
    [SerializeField] private Transform _transform = null;
    [SerializeField] private Vector3 _input = Vector3.zero;
    public Vector3 Input { get => _input; set => _input = value; }

    private void Update()
    {
        Debug.Log(_input.magnitude);
        if (_input.magnitude > 0.1f)
            _transform.rotation = Quaternion.LookRotation(_input);
    }

    private void OnDisable()
    {
        _transform.localRotation = Quaternion.identity;
    }
}
