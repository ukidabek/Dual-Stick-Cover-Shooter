using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters.Player
{
    public class OnPlayerRemoved : OnPlayerEventHadler
    {
        protected override void Register()
        {
            PlayerController.PlayerRemoved += OnPlayerCallback;
        }

        protected override void UnRegister()
        {
            PlayerController.PlayerRemoved -= OnPlayerCallback;
        }
    }
}