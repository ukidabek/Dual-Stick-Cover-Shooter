using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanic.BaseClasses
{
    [DisallowMultipleComponent]
    public abstract class BaseMechanic : MonoBehaviour
    {
        public string Name { get => gameObject.name; }

        protected virtual void Awake()
        {
            enabled = false;
        }

        protected virtual void Reset()
        {
            enabled = false;
            gameObject.name = GetType().Name;
        }
    }
}