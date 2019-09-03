using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    [Serializable] public class ToggleStatusCallback : UnityEvent<bool> { }

    public class ToggleController : MonoBehaviour
    {
        [SerializeField] private bool _status;

        public ToggleStatusCallback ToggleStatus = new ToggleStatusCallback();
        public ToggleStatusCallback InvertedToggleStatus = new ToggleStatusCallback();


        private void Awake()
        {
            ToggleStatus.Invoke(_status);
            InvertedToggleStatus.Invoke(!_status);
        }

        public void Toggle()
        {
            ToggleStatus.Invoke(_status = !_status);
            InvertedToggleStatus.Invoke(!_status);
        }
    }
}