using UnityEngine;
using Mechanic.BaseClasses;
using Player;
using UnityEngine.Serialization;

namespace Player.Movement
{
    public class NormalMovementAnimationController : BaseMechanic
    {
        [SerializeField] private Animator _animator = null;
        [FormerlySerializedAs("_parametraName")] 
        [SerializeField] private string m_parameterName = "Vertical";
        private int _parametraHash = 0;
        [Space]
        [SerializeField] private Vector3 _input = Vector3.zero;
        public Vector3 MoveInput { get => _input; set => _input = value; }

        protected override void Awake()
        {
            base.Awake();
            _parametraHash = Animator.StringToHash(m_parameterName);
        }

        private void Update()
        {
            _animator.SetFloat(_parametraHash, Mathf.Abs(_input.magnitude));
        }
    }
}