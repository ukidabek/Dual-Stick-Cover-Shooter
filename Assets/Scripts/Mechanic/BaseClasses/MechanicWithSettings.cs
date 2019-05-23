using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanic.BaseClasses
{
    public abstract class MechanicWithSettings<SettingsType> : BaseMechanic where SettingsType : ScriptableObject
    {
        [SerializeField] protected SettingsType settings = null; 
    }
}
