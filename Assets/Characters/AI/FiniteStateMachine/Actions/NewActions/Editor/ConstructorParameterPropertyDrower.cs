using UnityEditor;
using UnityEngine;

namespace AI.Actions
{
    [CustomPropertyDrawer(typeof(ConstructorParameter))]
    public class ConstructorParameterPropertyDrower : PropertyDrawer
    {
        private SerializedProperty parametrType;
        private SerializedProperty parametrName;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            parametrType = property.FindPropertyRelative("typeInfo._typeFullName");
            parametrName = property.FindPropertyRelative("_parameterFullName");
            return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProperty = null;
            switch (parametrType.stringValue)
            {
                case "System.Int32":
                    valueProperty = property.FindPropertyRelative("IntValue");
                    valueProperty.intValue = EditorGUI.IntField(position, parametrName.stringValue, valueProperty.intValue);
                    break;
                case "System.Single":
                    valueProperty = property.FindPropertyRelative("FloatValue");
                    valueProperty.floatValue = EditorGUI.FloatField(position, parametrName.stringValue, valueProperty.floatValue);
                    break;
                case "System.Boolean":
                    valueProperty = property.FindPropertyRelative("BoolValue");
                    valueProperty.boolValue = EditorGUI.Toggle(position, parametrName.stringValue, valueProperty.boolValue);
                    break;
                case "System.String":
                    valueProperty = property.FindPropertyRelative("StringValue");
                    valueProperty.stringValue = EditorGUI.TextField(position, parametrName.stringValue, valueProperty.stringValue);
                    break;
                //case "System.Color":
                //    return property.FindPropertyRelative("IntValue");
                default:
                    break;
            }

            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
