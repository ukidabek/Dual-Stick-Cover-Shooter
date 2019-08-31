using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace AI.Actions
{
    [CustomPropertyDrawer(typeof(AIStateAction))]
    public class AIStateActionPropertyDrower : PropertyDrawer
    {
        private SerializedProperty taskType;
        private SerializedProperty taskTypeFullName;
        private SerializedProperty taskTypeFullNameAssemblyName;
        private SerializedProperty constructorIndex;
        private SerializedProperty constructorParameters;
        private List<Type> types = new List<Type>();
        private List<string> typeNames = new List<string>();
        private Type baseType;
        private Assembly assembly;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            taskType = property.FindPropertyRelative("taskType");
            taskTypeFullName = taskType.FindPropertyRelative("_typeFullName");
            taskTypeFullNameAssemblyName = taskType.FindPropertyRelative("_assembylFullName");

            constructorIndex = property.FindPropertyRelative("constructorIndex");
            constructorParameters = property.FindPropertyRelative("constructorParameters");

            baseType = typeof(AIStateActionTask);
            assembly = baseType.Assembly;
            foreach (var item in assembly.GetTypes())
            {
                if (item.IsSubclassOf(baseType) && !item.IsAbstract)
                {
                    types.Add(item);
                    typeNames.Add(item.Name);
                }
            }

            if (types.Count == 0) constructorParameters.ClearArray();

            return EditorGUIUtility.singleLineHeight * (2 + constructorParameters.arraySize);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.height = EditorGUIUtility.singleLineHeight;
            int typeIndex = GetTypeIndex(types, taskTypeFullName);

            if(types.Count == 0)
            {
                EditorGUI.LabelField(position, "No actions tasks!");
                return;
            }

            typeIndex = EditorGUI.Popup(position, typeIndex, typeNames.ToArray());
            typeIndex = typeIndex < 0 ? 0 : typeIndex;

            taskTypeFullName.stringValue = types[typeIndex].FullName;
            taskTypeFullNameAssemblyName.stringValue = types[typeIndex].Assembly.FullName;

            // Gathering all constructors of class; 
            var constructors = types[typeIndex].GetConstructors();
            int constructorIndex = this.constructorIndex.intValue;
            // Generating a labels form all gathered constructors.
            string[] constructorLabels = GetConstructorLabels(constructors);

            position.y += EditorGUIUtility.singleLineHeight;
            if(constructorParameters.arraySize != constructors[constructorIndex].GetParameters().Length)
                constructorIndex = SetConstructorParameters(0, constructors);
            else
            {
                int selectedConstructorIndex = EditorGUI.Popup(position, constructorIndex, constructorLabels);
                if (selectedConstructorIndex != typeIndex)
                    constructorIndex = SetConstructorParameters(selectedConstructorIndex, constructors);
            }

            for (int i = 0; i < constructorParameters.arraySize; i++)
            {
                var x = constructorParameters.GetArrayElementAtIndex(i);
                position.y += EditorGUI.GetPropertyHeight(x);
                EditorGUI.PropertyField(position, constructorParameters.GetArrayElementAtIndex(i));
            }

            property.serializedObject.ApplyModifiedProperties();
        }

        private int SetConstructorParameters(int selectedConstructorIndex, ConstructorInfo[] constructors)
        {
            constructorIndex.intValue =  selectedConstructorIndex;
            this.constructorParameters.ClearArray();
            var constructorParameters = constructors[selectedConstructorIndex].GetParameters();
            this.constructorParameters.arraySize = constructorParameters.Length;

            for (int i = 0; i < this.constructorParameters.arraySize; i++)
                SetConstructorParameter(this.constructorParameters.GetArrayElementAtIndex(i), constructorParameters[i]);
            return selectedConstructorIndex;
        }

        private string[] GetConstructorLabels(ConstructorInfo[] constructors)
        {
            string[] constructorLabelText = new string[constructors.Length];
            for (int i = 0; i < constructorLabelText.Length; i++)
            {
               string data = "(";
                var parameters = constructors[i].GetParameters();
                for (int j = 0; j < parameters.Length; j++)
                {
                    string[] segments = parameters[j].ParameterType.FullName.Split('.');
                    string name = segments[segments.Length - 1];
                    data += string.Format("{0} {1}{2}", name, parameters[j].Name, j < parameters.Length - 1 ? ", " : string.Empty);
                }
                data += ")";
                constructorLabelText[i] = data;
            }
            return constructorLabelText;
        }

        private int GetTypeIndex(List<Type> types, SerializedProperty taskTypeFullName)
        {
            for (int i = 0; i < types.Count; i++)
                if (types[i].FullName == taskTypeFullName.stringValue)
                    return i;

            return -1;
        }

        private void SetConstructorParameter(SerializedProperty constructorParameter, ParameterInfo parameterInfo)
        {
            constructorParameter.FindPropertyRelative("_parameterFullName").stringValue = parameterInfo.Name;
            constructorParameter.FindPropertyRelative("typeInfo._typeFullName").stringValue = parameterInfo.ParameterType.FullName;
            constructorParameter.FindPropertyRelative("typeInfo._assembylFullName").stringValue = parameterInfo.ParameterType.Assembly.FullName;
        }
    }
}