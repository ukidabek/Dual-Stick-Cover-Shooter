using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Mechanic
{
    public class MechanicsScriptGenerator : EditorWindow
    {
        private const string Usings = "using UnityEngine;\r\nusing Mechanic.BaseClasses;\r\n\r\n";
        private const string Mechanic_Class_Heder = "public class {0} : MechanicWithSettings<{0}Settings>";
        private const string Mechanic_Settings_Class_Heder = "[CreateAssetMenu(fileName = \"{0} Settings.asset\", menuName = \"Settings/{0} Settings\")]\r\npublic class {0}Settings : ScriptableObject";
        private const string Class_Body = "\r\n{\r\n}\r\n";

        private string _name = string.Empty;
        private string _path = string.Empty;

        [MenuItem("Window/Mechanics Script Generator")]
        static void Init()
        {
            MechanicsScriptGenerator window = (MechanicsScriptGenerator)GetWindow(typeof(MechanicsScriptGenerator));
            window.minSize = window.maxSize = new Vector2(300, 50);
            window.SelectPath();
            window.Show();
        }

        private void SelectPath()
        {
            if (Selection.activeObject != null)
            {
                _path = AssetDatabase.GetAssetPath(Selection.activeObject);
                if (!string.IsNullOrEmpty(Path.GetExtension(_path)))
                {
                    string fileName = Path.GetFileName(_path);
                    _path = _path.Replace("/" + fileName, "");
                }
            }
            else
                _path = Application.dataPath;
        }

        private void OnSelectionChange()
        {
            SelectPath();
        }

        private void OnGUI()
        {
            _name = EditorGUILayout.TextField("Mechanic script name: ", _name);
            EditorGUILayout.LabelField(string.Format("Path: {0}", _path));
            if (GUILayout.Button("Generate"))
                GenerateMechanicScipts();
        }

        private void GenerateMechanicScipts()
        {
            string data = Usings + string.Format(Mechanic_Class_Heder, _name) + Class_Body;
            File.WriteAllText(string.Format("{0}/{1}.cs", _path, _name), data);
            data = Usings + string.Format(Mechanic_Settings_Class_Heder, _name) + Class_Body;
            File.WriteAllText(string.Format("{0}/{1}Settings.cs", _path, _name), data);
            AssetDatabase.Refresh();
        }
    }
}