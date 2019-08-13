using UnityEngine;
using Mechanic.BaseClasses;
using Player;

namespace Player.Movement
{
    public class NormalMovementAnimationController : BaseMechanic
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private string _parametraName = "Vertical";
        private int _parametraHash = 0;
        [Space]
        [SerializeField] private Vector3 _input = Vector3.zero;
        public Vector3 MoveInput { get => _input; set => _input = value; }

        protected override void Awake()
        {
            base.Awake();
            _parametraHash = Animator.StringToHash(_parametraName);
        }

        private void Update()
        {
            _animator.SetFloat(_parametraHash, Mathf.Abs(_input.magnitude));
        }
    }
}