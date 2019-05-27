﻿using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class CommandManager : SingletonMonoBehaviour<CommandManager>
    {
        [SerializeField] private bool debugLog = false;
        private Queue<Command> commands = new Queue<Command>();

        private void Update()
        {
            if (commands.Count > 0)
                while (commands.Count > 0)
                {
                    var command = commands.Dequeue();
                    if (debugLog) Debug.LogFormat("Command type of {0} executed.", command.GetType().Name);
                    command.Execute();
                }
        }

        public void EnqueueCommand(Command command)
        {
            if (command != null)
                commands.Enqueue(command);
        }
    }
}