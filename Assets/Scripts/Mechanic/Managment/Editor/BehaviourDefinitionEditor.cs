using Mechanic.BaseClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Mechanic.Managment
{
    [CustomEditor(typeof(BehaviourDefinition))]
    public class BehaviourDefinitionEditor : Editor
    {
        private GameObject gameObject = null;
        private List<BaseMechanic> baseMechanics = null;
        private GenericMenu contextMenu = new GenericMenu();

        private bool showList = false;

        private void OnEnable()
        {
            baseMechanics = target.GetType().GetField("baseMechanics", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(target) as List<BaseMechanic>;
            gameObject = (target as MonoBehaviour).gameObject;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (var type in assembly.GetTypes())
                    if (type.IsSubclassOf(typeof(BaseMechanic)) && !type.IsAbstract)
                        contextMenu.AddItem(new GUIContent(type.Name), false, AddMechanic, type);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            showList = EditorGUILayout.Foldout(showList, serializedObject.FindProperty("baseMechanics").displayName);
            if (showList)
            {
                EditorGUI.indentLevel = 1;
                for (int i = 0; i < baseMechanics.Count; i++)
                {
                    if (baseMechanics[i] != null)
                    {
                        EditorGUILayout.BeginHorizontal();
                        {
                            baseMechanics[i] = EditorGUILayout.ObjectField(baseMechanics[i], baseMechanics[i].GetType(), true) as BaseMechanic;
                            if (GUILayout.Button("Remove", GUILayout.Width(60)))
                            {
                                DestroyImmediate(baseMechanics[i]);
                                baseMechanics.RemoveAt(i--);
                            }
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    else
                        baseMechanics.RemoveAt(i--);
                }
            }
            if (GUILayout.Button("Add Mechanic")) contextMenu.ShowAsContext();
        }

        private void AddMechanic(object mechanicType)
        {
            if (mechanicType is Type) Debug.Log((mechanicType as Type).Name);
            var newGameObject = new GameObject();
            newGameObject.transform.SetParent(gameObject.transform, false);
            baseMechanics.Add(newGameObject.AddComponent((mechanicType as Type)) as BaseMechanic);
        }
    }
}