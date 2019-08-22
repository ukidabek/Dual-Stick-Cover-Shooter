using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    [Serializable] public class OnUseerActionCallback : UnityEvent<GameObject> { }
    [Serializable] public class OnInteractionStatusChange : UnityEvent<bool> { }

    public class Interaction : MonoBehaviour
    {
        public OnUseerActionCallback OnUseCallback = new OnUseerActionCallback();
        public OnUseerActionCallback OnLeaveCallback = new OnUseerActionCallback();
        public OnInteractionStatusChange OnInteractionStatusChange = new OnInteractionStatusChange();
        public UnityEvent OnInteractionShow = new UnityEvent();
        public UnityEvent OnInteractionHide = new UnityEvent();

        private GameObject user = null;

        [SerializeField] private bool _isInteractionShown = false;

        public void Use(GameObject user)
        {
            OnUseCallback.Invoke(this.user = user);
            Debug.LogFormat("Interaction {0} used by {1}.", this.gameObject.name, user.name);
        }

        public void Leave()
        {
            OnLeaveCallback.Invoke(user);
            Debug.LogFormat("Interaction {0} leaved by {1}.", this.gameObject.name, user.name);
        }

        public void Show()
        {
            if (!_isInteractionShown)
            {
                OnInteractionStatusChange.Invoke(_isInteractionShown = true);
                OnInteractionShow.Invoke();
                Debug.LogFormat("Interaction {0} show.", gameObject.name);
            }
        }

        public void Hide()
        {
            if (_isInteractionShown)
            {
                OnInteractionStatusChange.Invoke(_isInteractionShown = false);
                OnInteractionHide.Invoke();
                Debug.LogFormat("Interaction {0} hide.", gameObject.name);
            }
        }
    }
}