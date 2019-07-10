using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Player
{
    public interface IMove
    {
        Vector3 MoveInput { get; set; }
    }
    public interface IAim
    {
        Vector3 MoveInput { get; set; }
    }

    public interface IAimToggle
    {
        bool Activate { get; set; }
    }

    public interface IFire
    {
        bool Activate { get; set; }
    }

    public class PlayerController : MonoBehaviour
    {
        private static List<PlayerController> players = new List<PlayerController>();
        public static ReadOnlyCollection<PlayerController> Players = null;

        public static event Action PlayerListUpdated = null;
        public static event Action<PlayerController> PlayerAdded = null;
        public static event Action<PlayerController> PlayerRemoved = null;

        private IMove[] _movementHandlers = null;
        private IAim[] _aimHandlers = null;
        private IAimToggle[] _aimToggles = null;
        private IFire[] _fires = null;
        private IUse[] _uses = null;

        private string _defaultName = string.Empty;
        [SerializeField] private int _playerID = 0;
        public int PlayerID { get => _playerID; }

        private void OnEnable()
        {
            if (Players == null) Players = new ReadOnlyCollection<PlayerController>(players);
            Add();
            transform.root.name = string.Format("{0} {1}", _defaultName, players.Count.ToString());
        }

        private void Awake()
        {
            _defaultName = transform.root.name;
            var gameObject = transform.root;
            _movementHandlers = gameObject.GetComponentsInChildren<IMove>();
            _aimHandlers = gameObject.GetComponentsInChildren<IAim>();
            _aimToggles = gameObject.GetComponentsInChildren<IAimToggle>();
            _fires = gameObject.GetComponentsInChildren<IFire>();
            _uses = gameObject.GetComponentsInChildren<IUse>();
        }

        public void Move(Vector3 input)
        {
            for (int i = 0; i < _movementHandlers.Length; i++)
                _movementHandlers[i].MoveInput = input;
        }

        public void Aim(Vector3 input)
        {
            for (int i = 0; i < _aimHandlers.Length; i++)
                _aimHandlers[i].MoveInput = input;
        }

        public void Aim(bool activate)
        {
            for (int i = 0; i < _aimToggles.Length; i++)
                _aimToggles[i].Activate = activate;
        }

        public void Fire(bool activate)
        {
            for (int i = 0; i < _fires.Length; i++)
                _fires[i].Activate = activate;
        }

        public void Use()
        {
            for (int i = 0; i < _uses.Length; i++)
                _uses[i].Use();
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            UnityEditor.Handles.color = Color.black;
            UnityEditor.Handles.Label(transform.root.transform.position + Vector3.up, transform.root.name);
#endif
        }

        private void Add()
        {
            players.Add(this);
            _playerID = players.Count;
            PlayerAdded?.Invoke(this);
            PlayerListUpdated?.Invoke();
        }

        private void Remove()
        {
            players.Remove(this);
            PlayerRemoved?.Invoke(this);
            PlayerListUpdated?.Invoke();
        }

        private void OnDisable()
        {
            Remove();
        }

        private void OnDestroy()
        {
            Remove();
        }
    }
}