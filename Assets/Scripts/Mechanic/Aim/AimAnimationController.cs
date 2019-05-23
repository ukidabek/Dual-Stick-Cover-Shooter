using UnityEngine;
using Mechanic.BaseClasses;

public class AimAnimationController : MechanicWithSettings<AimAnimationControllerSettings>
{
    [SerializeField] private Transform _transform = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Vector3 _input = Vector3.zero;
    public Vector3 Input { get => _input; set => _input = value; }

    [SerializeField] private Vector3 _localizedInput = Vector3.zero;

    private void Update()
    {
        _localizedInput = _transform.InverseTransformDirection(_input).normalized;
        _animator.SetFloat("Horizontal",_localizedInput.x);
        _animator.SetFloat("Vertical", _localizedInput.z);
    }

}
