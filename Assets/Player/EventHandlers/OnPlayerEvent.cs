using System;
using UnityEngine.Events;

namespace Player
{
    [Serializable] public class OnPlayerEvent : UnityEvent<PlayerController> { }
}