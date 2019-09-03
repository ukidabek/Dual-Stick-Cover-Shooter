using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Weapons.Animations
{
    [CustomEditor(typeof(WeaponAnimationParametrSeter))]
    public class WeaponAnimationParametrSeterEdytor : Editor
    {
        private SerializedProperty _typeValue = null;
        private SerializedProperty _boolValue = null;

        private void OnEnable()
        {
            _typeValue = serializedObject.FindProperty("_parametrToSet");
            _boolValue = serializedObject.FindProperty("_boolValue");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if ((WeaponAnimationParametrSeter.ParametrToSet)_typeValue.enumValueIndex == WeaponAnimationParametrSeter.ParametrToSet.Bool)
                _boolValue.boolValue = EditorGUILayout.Toggle("BoolValue", _boolValue.boolValue);
            serializedObject.ApplyModifiedProperties();
        }
    }
}