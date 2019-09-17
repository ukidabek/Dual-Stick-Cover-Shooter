using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Statistics
{
    [CustomPropertyDrawer(typeof(Type), true)]
    public class NewBehaviourScript : TypePropertyDrower<StatTypeManager> { }
}