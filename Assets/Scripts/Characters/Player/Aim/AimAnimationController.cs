using Mechanic.BaseClasses;
using Player;
using UnityEngine;

namespace Player.Aim
{
    public class AimAnimationController : BaseMechanic
    {
        [Tooltip("Transfomr that will be used to calculate inverse transform direction. If null Animator transfomr will be used.")]
        [SerializeField] private Transform _transform = null;
        [Tooltip("Animator that contains aim and movement animations.")]
        [SerializeField] private Animator _animator = null;
        [SerializeField] private Vector3 _input = Vector3.zero;
        public Vector3 MoveInput { get => _input; set => _input = value; }

        [SerializeField] private Vector3 _localizedInput = Vector3.zero;

        [Space]
        [SerializeField] private string _aimParametraName = "Aim";
        private int _aimParametraHash = 0;
        [SerializeField] private string _verticalParametraName = "Vertical";
        private int _verticalParametraHash = 0;
        [SerializeField] private string _horizontalParametraName = "Horizontal";
        private int _horizontalParametraHash = 0;

        protected override void Awake()
        {
            base.Awake();
            _aimParametraHash = Animator.StringToHash(_aimParametraName);
            _verticalParametraHash = Animator.StringToHash(_verticalParametraName);
            _horizontalParametraHash = Animator.StringToHash(_horizontalParametraName);
        }

        private void OnEnable()
        {
            _animator.SetBool(_aimParametraName, true);
        }

        private void Update()
        {
            _localizedInput = (_transform == null ? _animator.transform : _transform).InverseTransformDirection(_input).normalized;
            _animator.SetFloat(_horizontalParametraName, _localizedInput.x);
            _animator.SetFloat(_verticalParametraName, _localizedInput.z);
        }

        private void OnDisable()
        {
            _animator.SetBool(_aimParametraName, false);
            _animator.SetFloat(_horizontalParametraName, 0);
        }
    }
}