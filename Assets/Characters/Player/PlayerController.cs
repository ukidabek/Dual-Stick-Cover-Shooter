using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

namespace Characters.Player
{
    public class PlayerController : CharacterController
    {
        private static List<PlayerController> players = new List<PlayerController>();
        public static ReadOnlyCollection<PlayerController> Players = null;

        [SerializeField] private int _playerID = 0;
        public int PlayerID { get => _playerID; }

        public static event Action PlayerListUpdated = null;
        public static event Action<PlayerController> PlayerAdded = null;
        public static event Action<PlayerController> PlayerRemoved = null;

        [Serializable] public class InputUpdateEvent : UnityEvent<Vector3> { }
        [Serializable] public class InputToggleUpdateEvent : UnityEvent<bool> { }

        [Space]
        public InputUpdateEvent UpdateMovementInput = new InputUpdateEvent();
        public InputUpdateEvent UpdateLookInput = new InputUpdateEvent();
        public InputToggleUpdateEvent UpdateAimToggle = new InputToggleUpdateEvent();
        public InputToggleUpdateEvent UpdateFireToggle = new InputToggleUpdateEvent();
        public UnityEvent UpdateUse = new UnityEvent();

        private void OnEnable() { }

        protected override void Awake()
        {
            base.Awake();
            if (Players == null) Players = new ReadOnlyCollection<PlayerController>(players);
        }

        protected override void Start()
        {
            Add(this);
            transform.root.name = string.Format("{0} {1}", transform.root.name, players.Count.ToString());
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            UnityEditor.Handles.color = Color.black;
            UnityEditor.Handles.Label(transform.root.transform.position + Vector3.up, transform.root.name);
#endif
        }

        protected override void Add(CharacterController character)
        {
            players.Add(character as PlayerController);
            _playerID = players.Count;
            PlayerAdded?.Invoke(character as PlayerController);
            PlayerListUpdated?.Invoke();
            base.Add(character);
        }

        protected override void Remove(CharacterController character)
        {
            players.Remove(character as PlayerController);
            PlayerRemoved?.Invoke(character as PlayerController);
            PlayerListUpdated?.Invoke();
            base.Remove(character);
        }
    }
}