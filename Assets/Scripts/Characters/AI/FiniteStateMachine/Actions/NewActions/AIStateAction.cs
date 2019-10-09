using System;
using System.Reflection;
using UnityEngine;

namespace AI.Actions
{
    [Serializable]
    public class AIStateAction
    {
        [SerializeField] private TypeInfo taskType = null;
        [SerializeField] private ConstructorParameter[] constructorParameters = null;

        private AIStateActionTask task = null;
        private bool isInitialized= false;

        public void Initilize()
        {
            if (!isInitialized)
            {
                isInitialized = true;
                object[] data = new object[constructorParameters.Length];
                for (int i = 0; i < constructorParameters.Length; i++)
                    data[i] = constructorParameters[i].GetValue();

                task = Activator.CreateInstance(taskType, data) as AIStateActionTask;
            }
        }

        public void Perform(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            Initilize();
            task.Perform(animator, animatorStateInfo, layerIndex);
        }
    }

    [Serializable]
    public class ConstructorParameter
    {
        [SerializeField] private TypeInfo typeInfo = new TypeInfo();
        [SerializeField] private string _parameterFullName = string.Empty;

        [SerializeField] private int IntValue = 0;
        [SerializeField] private float FloatValue = 0f;
        [SerializeField] private bool BoolValue = false;
        [SerializeField] private string StringValue = string.Empty;

        public object GetValue()
        {
            switch (typeInfo.TypeFullName)
            {
                case "System.Int32":
                    return IntValue;
                case "System.Single":
                    return FloatValue;
                case "System.Boolean":
                    return BoolValue;
                case "System.String":
                    return StringValue;
                //case "System.Color":
                //    return property.FindPropertyRelative("IntValue");
                default:
                    return null;
            }
        }
    }

    [Serializable]
    public class TypeInfo
    {
        [SerializeField] private string _typeFullName = string.Empty;
        public string TypeFullName { get => _typeFullName; }

        [SerializeField] private string _assembylFullName = string.Empty;
        public string AssembylFullName { get => _assembylFullName; }

        private Type _type = null;

        public TypeInfo() { }

        public TypeInfo(Type type)
        {
            _assembylFullName = type.Assembly.GetName().FullName;
            _typeFullName = type.FullName;
        }


        public static implicit operator Type(TypeInfo taskTypeInfo)
        {
            if (taskTypeInfo == null || string.IsNullOrEmpty(taskTypeInfo._assembylFullName) || string.IsNullOrEmpty(taskTypeInfo._typeFullName))
                return null;

            if (taskTypeInfo._type == null)
                foreach (Assembly item in AppDomain.CurrentDomain.GetAssemblies())
                    if (item.GetName().FullName == taskTypeInfo._assembylFullName)
                    {
                        taskTypeInfo._type = item.GetType(taskTypeInfo._typeFullName);
                        break;
                    }

            return taskTypeInfo._type;
        }
    }
}
