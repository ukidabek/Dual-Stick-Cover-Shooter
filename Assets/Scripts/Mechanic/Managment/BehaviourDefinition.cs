using Mechanic.BaseClasses;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanic.Managment
{
    [DisallowMultipleComponent]
    public class BehaviourDefinition : MonoBehaviour
    {
        public string Name { get { return gameObject.name; } }

        [SerializeField] private bool _enabled = false;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    foreach (var item in baseMechanics)
                        item.enabled = value;
                }
            }
        }

        [SerializeField] private List<BaseMechanic> baseMechanics = new List<BaseMechanic>();
    }
}