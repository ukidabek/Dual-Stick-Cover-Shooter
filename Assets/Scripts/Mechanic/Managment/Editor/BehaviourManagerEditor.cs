using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Mechanic.Managment
{
    [CustomEditor(typeof(BehaviourManager))]
    public class BehaviourManagerEditor : Editor
    {
        private BehaviourManager behaviourManager = null;
        private List<BehaviourDefinition> _behaviours = null;

        private string newBehaviorName = string.Empty;

        private int index = -1;
        private List<string> behaviorNames = new List<string>();
        private FieldInfo defaultBehavior = null;

        private void OnEnable()
        {
            behaviourManager = target as BehaviourManager;
            var behaviorsList = behaviourManager.GetType().GetField("_behaviours", BindingFlags.NonPublic | BindingFlags.Instance);
            defaultBehavior = behaviourManager.GetType().GetField("_defaultBehavior", BindingFlags.NonPublic | BindingFlags.Instance);

            _behaviours = (List<BehaviourDefinition>)behaviorsList.GetValue(behaviourManager);

            GetBehaviorNames();
        }

        private void GetBehaviorNames()
        {
            behaviorNames.Clear();
            foreach (var item in _behaviours)
                behaviorNames.Add(item.Name);

            index = behaviorNames.IndexOf((string)defaultBehavior.GetValue(behaviourManager));
            if (index < 0 && behaviorNames.Count > 0)
                index = 0;
        }

        public void AddBehaviour(string name)
        {
            GameObject newBehaviour = new GameObject(name, typeof(BehaviourDefinition));
            newBehaviour.transform.SetParent(behaviourManager.transform);
            _behaviours.Add(newBehaviour.GetComponent<BehaviourDefinition>());
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (behaviorNames.Count != _behaviours.Count)
                GetBehaviorNames();

            GUILayout.Space(10);
            if (index >= 0)
            {
                var newIndex = EditorGUILayout.Popup("Default behavior: ", index, behaviorNames.ToArray());
                if (newIndex != index)
                {
                    defaultBehavior.SetValue(behaviourManager, behaviorNames[newIndex]);
                    index = newIndex;
                }
                EditorGUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Name: ");
                    newBehaviorName = GUILayout.TextField(newBehaviorName);
                    if (GUILayout.Button("Add", GUILayout.Height(15)) && !string.IsNullOrEmpty(newBehaviorName))
                    {
                        AddBehaviour(newBehaviorName);
                        newBehaviorName = string.Empty;
                    }
                }
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(10);
            }

            for (int i = 0; i < _behaviours.Count; i++)
            {
                var item = _behaviours[i];
                if (item.Name != behaviorNames[i])
                    GetBehaviorNames();

                GUI.enabled = Application.isPlaying;
                Color old = GUI.color;
                if (item.Enabled)
                    GUI.color = Color.red;
                if (GUILayout.Button(item.Name))
                    behaviourManager.ActivateBehavior(item.Name);

                GUI.color = old;
            }
        }
    }
}