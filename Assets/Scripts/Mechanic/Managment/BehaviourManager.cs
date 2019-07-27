using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanic.Managment
{
    public class BehaviourManager : MonoBehaviour
    {
        private const string GameObject_Name_Format = "{0} - {1}";
        private string _cahedObjectName = string.Empty;
        private string _cahedRootName = string.Empty;

        [SerializeField, HideInInspector] private string _defaultBehavior = string.Empty;

        [SerializeField, HideInInspector] private List<BehaviourDefinition> _behaviours = new List<BehaviourDefinition>();

        private void Awake()
        {
            _cahedObjectName = gameObject.name;
            _cahedRootName = gameObject.transform.root.gameObject.name;
        }

        internal void ActivateDfaultBehavior()
        {
            ActivateBehavior(_defaultBehavior);
        }

        public void ActivateBehavior(string name)
        {
            foreach (var item in _behaviours)
                if (item.Enabled = item.Name == name)
                {
                    gameObject.name = string.Format(GameObject_Name_Format, _cahedObjectName, name);
                    Debug.Log(string.Format("{0} behavior set for {1} activated", name, _cahedRootName), this);
                }
        }

        public void DisableAllBehaaviors()
        {
            foreach (var item in _behaviours)
                item.Enabled = false;
        }

        private void Start()
        {
            ActivateDfaultBehavior();
        }

        private void Reset()
        {
            gameObject.name = GetType().Name;
        }
    }
}