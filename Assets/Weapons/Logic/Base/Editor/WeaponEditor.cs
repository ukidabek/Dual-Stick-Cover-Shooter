using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Weapons
{
    [CustomEditor(typeof(Weapon))]
    public class WeaponEditor : Editor
    {
        private GUIStyle GUIStyle = null;

        private void OnEnable()
        {
            GUIStyle = new GUIStyle();
            GUIStyle.alignment = TextAnchor.LowerCenter;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("Previus", GUILayout.Width(60))) (target as Weapon).PreviusMode();
                GUILayout.Label((target as Weapon).SeledtedMode == null ? "Non" : (target as Weapon).SeledtedMode.GetModeType(), GUIStyle); ;
                if (GUILayout.Button("Next", GUILayout.Width(60))) (target as Weapon).NextMode();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
