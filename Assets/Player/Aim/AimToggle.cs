using Mechanic.Managment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class AimToggle : BehaviourToggle, IAimToggle
{
    public bool Activate { get => this.IsOn; set => IsOn = value; }
}
