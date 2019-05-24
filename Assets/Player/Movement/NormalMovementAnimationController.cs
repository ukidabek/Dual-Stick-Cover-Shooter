using UnityEngine;
using Mechanic.BaseClasses;

public class NormalMovementAnimationController : MechanicWithSettings<NormalMovementAnimationControllerSettings>
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Vector3 _input = Vector3.zero;
    public Vector3 Input { get => _input; set => _input = value; }

    private void Update()
    {
        _animator.SetFloat("Vertical", Mathf.Abs(_input.normalized.magnitude));
    }
}
