using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DependencyInjection), true)]
public class DependencyInjectionPropertyDrawer : PropertyDrawer
{
    private string[] _availableFields;
    private SerializedProperty selectedObjectProperty;
    private SerializedProperty lookInChildrenProperty;
    private int index = 0;
    private SerializedProperty fieldNameProperty;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var rect = new Rect(position.x, 
            position.y, 
            position.width, 
            EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(rect, selectedObjectProperty);
        rect = new Rect(position.x, 
            position.y + EditorGUIUtility.singleLineHeight, 
            position.width, 
            EditorGUIUtility.singleLineHeight);
        if (selectedObjectProperty.objectReferenceValue != null)
        {
            var newIndex = EditorGUI.Popup(rect,
                new GUIContent("Selected field"),
                index,
                _availableFields.Select(s => new GUIContent(s)).ToArray());
            if (newIndex != index)
            {
                index = newIndex;
                fieldNameProperty.stringValue = _availableFields[index];
            }
        }
        else
            EditorGUI.LabelField(rect, "Select object");

        rect = new Rect(position.x, 
            position.y + EditorGUIUtility.singleLineHeight * 2, 
            position.width, 
            EditorGUIUtility.singleLineHeight);
        
        EditorGUI.PropertyField(rect, lookInChildrenProperty);
        property.serializedObject.ApplyModifiedProperties();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public;
        selectedObjectProperty = property.FindPropertyRelative("object");
        fieldNameProperty = property.FindPropertyRelative("fieldName");
        lookInChildrenProperty = property.FindPropertyRelative("lookInChildren");
        if (selectedObjectProperty.objectReferenceValue != null)
        {
            var selectedObject = property.FindPropertyRelative("object").objectReferenceValue.GetType();
            var fields = selectedObject
                .GetFields(bindingFlags)
                .Where(info => info.GetCustomAttributes().Any(attribute1 => attribute1.GetType() == typeof(SerializeField)))
                .Select(info => info.Name);
            var properties = selectedObject
                .GetProperties(bindingFlags)
                .Select(info => info.Name);

            var availableFields = new List<string>()
                .Concat(fields)
                .Concat(properties)
                .ToList();

            _availableFields = availableFields.ToArray();
            index = availableFields.IndexOf(fieldNameProperty.stringValue);
            if (index < 0)
                index = 0;
        }

     
        return EditorGUIUtility.singleLineHeight * 3;
    }
}
