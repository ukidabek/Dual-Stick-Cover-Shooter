using System;
using System.Collections;
using System.Collections.Generic;

namespace Characters.Player
{
    public class OnPlayerAdded : OnPlayerEventHadler
    {
        protected override void Register()
        {
            PlayerController.PlayerAdded += OnPlayerCallback;
        }

        protected override void UnRegister()
        {
            PlayerController.PlayerAdded -= OnPlayerCallback;
        }
    }
}