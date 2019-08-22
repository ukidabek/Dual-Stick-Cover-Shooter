using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Interactions
{
    [CustomEditor(typeof(OnTrggerInteractionUser))]
    public class OnTrggerInteractionUserEditor : Editor
    {
        private SerializedProperty _useAngleProperty = null;
        private SerializedProperty _interactionShowAngleProperty = null;

        private void OnEnable()
        {
            _useAngleProperty = serializedObject.FindProperty("_useAngle");
            _interactionShowAngleProperty = serializedObject.FindProperty("_interactionShowAngle");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (_useAngleProperty.boolValue)
                _interactionShowAngleProperty.floatValue = EditorGUILayout.Slider(
                    _interactionShowAngleProperty.displayName,
                    _interactionShowAngleProperty.floatValue,
                    0f,
                    360f);
        }
    }
}