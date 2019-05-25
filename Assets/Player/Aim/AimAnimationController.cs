using Mechanic.BaseClasses;
using UnityEngine;

public class AimAnimationController : BaseMechanic, IMove
{
    [SerializeField] private Transform _transform = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Vector3 _input = Vector3.zero;
    public Vector3 MoveInput { get => _input; set => _input = value; }

    [SerializeField] private Vector3 _localizedInput = Vector3.zero;

    private void Update()
    {
        _localizedInput = _transform.InverseTransformDirection(_input).normalized;
        _animator.SetFloat("Horizontal", _localizedInput.x);
        _animator.SetFloat("Vertical", _localizedInput.z);
    }

    private void OnDisable()
    {
        _animator.SetFloat("Horizontal", 0);
    }
}
