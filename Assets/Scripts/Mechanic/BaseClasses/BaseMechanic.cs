using Mechanic.Managment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanic.BaseClasses
{
    [DisallowMultipleComponent]
    public abstract class BaseMechanic : MonoBehaviour
    {
        protected BehaviourDefinition owner = null;
        public string Name { get => gameObject.name; }

        protected virtual void Awake()
        {
            enabled = false;
        }

        public void SetOwner(BehaviourDefinition owner)
        {
            this.owner = owner;
        }

        protected virtual void Reset()
        {
            enabled = false;
            gameObject.name = GetType().Name;
        }
    }
}