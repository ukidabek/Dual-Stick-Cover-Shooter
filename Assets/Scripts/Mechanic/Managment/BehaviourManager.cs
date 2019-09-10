using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanic.Managment
{
    public class BehaviourManager : MonoBehaviour
    {
#if UNITY_EDITOR
        private const string GameObject_Name_Format = "{0} - {1}";
        private const string Log_Format = "<color=#0000ffff>{0}</color> behavior set for <color=#0000ffff>{1}</color> activated";
#endif
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
#if UNITY_EDITOR
                    gameObject.name = string.Format(GameObject_Name_Format, _cahedObjectName, name);
                    Debug.Log(string.Format(Log_Format, name, _cahedRootName), this);
#endif
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