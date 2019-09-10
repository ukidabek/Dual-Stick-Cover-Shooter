using System;
using UnityEngine;

namespace Encounter
{
    public class ActorLifeCycleObserver : MonoBehaviour
    {
        public event Action<GameObject> OnDisabledCallback = null;
        public event Action<GameObject> OnDestroyedCallback = null;

        private void OnDisable()
        {
            OnDisabledCallback?.Invoke(gameObject);
#if UNITY_EDITOR
            Debug.LogFormat("Actor <color=#ffff00ff>{0}</color> deactivated", gameObject.name);
#endif
        }

        private void OnDestroy()
        {
            OnDestroyedCallback?.Invoke(gameObject);
#if UNITY_EDITOR
            Debug.LogFormat("Actor <color=#ff0000ff>{0}</color> destoryed", gameObject.name);
#endif
        }
    }
}