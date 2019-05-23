using Mechanic.Managment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanic.Managment
{
    [DisallowMultipleComponent]
    public class BehaviourSetter : MonoBehaviour
    {
        [SerializeField] private string _behaviourName = string.Empty;

        private BehaviourManager manager = null;

        public void SetBehaviour(GameObject gameObject)
        {
            if(gameObject != null)
            {
                manager = gameObject.GetComponentInChildren<BehaviourManager>();
                if (manager != null && !string.IsNullOrEmpty(_behaviourName))
                    manager.ActivateBehavior(_behaviourName);
            }
        }

        private void OnValidate()
        {
            gameObject.name = _behaviourName;
        }
    }
}