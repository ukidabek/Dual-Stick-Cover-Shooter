using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Weapon.Mode.Type))]
public class WeaponModeTypePropertyDrower : PropertyDrawer
{
    private SerializedProperty _name = null;
    private int index = -1;
    private string[] names = null;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        _name = property.FindPropertyRelative("_name");
        names = new string[WeaponModeTypeManager.Instance.TypesNames.Count];
        WeaponModeTypeManager.Instance.TypesNames.CopyTo(names, 0);
        return base.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (WeaponModeTypeManager.Instance.TypesNames.Count > 0)
        {
            index = WeaponModeTypeManager.Instance.TypesNames.IndexOf(_name.stringValue);
            index = index < 0 ? 0 : index;
            index = EditorGUI.Popup(position, index, names);
            property.serializedObject.ApplyModifiedProperties();
        }
        else
            EditorGUI.LabelField(position, "No weapon types mode types defined.");
        //base.OnGUI(position, property, label);
    }
}
