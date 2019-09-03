using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions.General
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private bool isLocked = false;
        public bool IsLocked { get => isLocked; }

        [SerializeField] private bool isOpen = false;
        public bool IsOpen { get => isOpen; }

        [Space]
        public OnStatusChange OnOpenStatusChange = new OnStatusChange();
        public OnStatusChange OnLockStatusChange = new OnStatusChange();

        public UnityEvent OnLock = new UnityEvent();
        public UnityEvent OnUnlock = new UnityEvent();
        public UnityEvent OnOpen = new UnityEvent();
        public UnityEvent OnClose = new UnityEvent();

        private void SetStatus(ref bool status, bool newStatus, OnStatusChange onStatusChange, UnityEvent onTrue, UnityEvent onFalse)
        {
            if (status != newStatus)
            {
                onStatusChange.Invoke(status = newStatus);
                if (status)
                    onTrue.Invoke();
                else
                    onFalse.Invoke();
            }

        }

        public void SetOpenStatus(bool status)
        {
            if(!isLocked)
            {
                SetStatus(ref isOpen, status, OnOpenStatusChange, OnOpen, OnClose);
            }
        }

        public void SetLockStatus(bool status)
        {
            SetStatus(ref isLocked, status, OnLockStatusChange, OnLock, OnUnlock);
        }

        public void Open()
        {
            SetOpenStatus(true);
        }

        public void Close()
        {
            SetOpenStatus(false);
        }

        public void Lock()
        {
            SetLockStatus(true);
        }

        public void Unlock()
        {
            SetLockStatus(false);
        }
    }
}