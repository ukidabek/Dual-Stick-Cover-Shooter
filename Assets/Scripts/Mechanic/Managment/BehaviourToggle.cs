using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanic.Managment
{
    public class BehaviourToggle : MonoBehaviour
    {
        [SerializeField] private BehaviourManager _behaviourManager = null;
        [SerializeField] private bool _isOn = false;
        [SerializeField] private string _behaviourToToggle = string.Empty;
        public bool IsOn
        {
            get => _isOn;
            set
            {
                if (_isOn = value)
                {
                    _behaviourManager.ActivateBehavior(_behaviourToToggle);
                }
                else
                    _behaviourManager.ActivateDfaultBehavior();
            }
        }


    }
}