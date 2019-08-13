using System;
using UnityEngine.Events;

namespace Characters.Player
{
    [Serializable] public class OnPlayerEvent : UnityEvent<PlayerController> { }
}