using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterWeaponEquipment))]
public class CharacterWeaponEquipmentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUI.enabled = Application.isPlaying;
        EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("Previous") && target is CharacterWeaponEquipment)
                (target as CharacterWeaponEquipment).Previous();
            if (GUILayout.Button("Next") && target is CharacterWeaponEquipment)
                (target as CharacterWeaponEquipment).Next();
        }
        EditorGUILayout.EndHorizontal();
    }
}
