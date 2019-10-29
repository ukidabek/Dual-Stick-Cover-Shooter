using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
	[Serializable] public class OnUseerActionCallback : UnityEvent<GameObject> { }
	[Serializable] public class OnStatusChange : UnityEvent<bool> { }

	public class Interaction : MonoBehaviour, IInteraction
	{
		[SerializeField] private bool _isInteractionShown = false;
		[SerializeField] private bool _active = true;
		public bool Active { get => _active; set => _active = value; }
		[SerializeField] private bool _useOnce = false;

		[Space]
		public OnUseerActionCallback OnUseCallback = new OnUseerActionCallback();
		public OnUseerActionCallback OnLeaveCallback = new OnUseerActionCallback();
		public OnStatusChange OnInteractionStatusChange = new OnStatusChange();
		public UnityEvent OnInteractionShow = new UnityEvent();
		public UnityEvent OnInteractionHide = new UnityEvent();

		private GameObject user = null;

		public Vector3 Position => transform.position;

		public void Use(GameObject user)
		{
			if (_active)
			{
				Debug.LogFormat("Interaction {0} used by {1}.\r\n<color=#008000ff>Interaction active!</color>", this.gameObject.name, user.name);
				if (_useOnce)
				{
					_active = false;
					Debug.LogFormat("Interaction {0} and marked as one-off. It will be deactivated.\r\n<color=#a52a2aff>Interaction deactivate!</color>", this.gameObject.name);
				}
				OnUseCallback.Invoke(this.user = user);
			}
			else
				Debug.LogFormat("Interaction {0} used by {1}.\r\n<color=#a52a2aff>Interaction inactive!</color>", this.gameObject.name, user.name);
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