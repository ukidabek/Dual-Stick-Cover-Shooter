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
        void Fire();
    }

    public class PlayerController : MonoBehaviour
    {
        private static List<PlayerController> players = new List<PlayerController>(); 
        public static ReadOnlyCollection<PlayerController> Players = null;
        public static event Action PlayerListUpdated = null;

        private IMove[] _movementHandlers = null;
        private IAim[] _aimHandlers = null;
        private IAimToggle[] _aimToggles = null;
        private IFire[] _fires = null;

        private string _defaultName = string.Empty; 

        private void OnEnable()
        {
            if (Players == null) Players = new ReadOnlyCollection<PlayerController>(players);
            players.Add(this);
            transform.root.name = string.Format("{0} {1}", _defaultName, players.Count.ToString());
            PlayerListUpdated?.Invoke();
        }

        private void Awake()
        {
            _defaultName = transform.root.name;
            _movementHandlers = gameObject.GetComponentsInChildren<IMove>();
            _aimHandlers = gameObject.GetComponentsInChildren<IAim>();
            _aimToggles = gameObject.GetComponentsInChildren<IAimToggle>();
            _fires = gameObject.GetComponentsInChildren<IFire>();
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

        public void Fire()
        {
            for (int i = 0; i < _fires.Length; i++)
                _fires[i].Fire();
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            UnityEditor.Handles.color = Color.black;
            UnityEditor.Handles.Label(transform.root.transform.position + Vector3.up, transform.root.name);
#endif
        }

        private void OnDisable()
        {
            players.Remove(this);
        }

        private void OnDestroy()
        {
            players.Remove(this);
        }
    }
}