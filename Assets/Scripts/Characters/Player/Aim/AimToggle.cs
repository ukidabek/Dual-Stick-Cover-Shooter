using Mechanic.Managment;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Aim
{
    [DisallowMultipleComponent]
    public class AimToggle : BehaviourToggle
    {
        public bool Activate { get => this.IsOn; set => IsOn = value; }
    }
}
