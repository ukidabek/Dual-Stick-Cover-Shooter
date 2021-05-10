using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;


[Serializable]
public class DependencyInjection
{
    [SerializeField] private string fieldName = string.Empty;
    [SerializeField] private Object @object = null;
    [SerializeField] private bool lookInChildren = false;

    private FieldInfo field = null;
    private PropertyInfo property = null;

    public void Apply(GameObject source)
    {
        if (field == null && property == null)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            field = @object.GetType().GetField(fieldName, bindingFlags);
            property = @object.GetType().GetProperty(fieldName, bindingFlags);
        }

        Component component = null;

        if (field != null)
        {
            component = GetComponent(source, field.FieldType, lookInChildren);
            field.SetValue(@object, component);
        }
        else if (property != null)
        {
            component = GetComponent(source, property.PropertyType, lookInChildren);
            property.SetValue(@object, component);
        }
    }

    private Component GetComponent(GameObject source, Type type, bool lookInChildren) => 
        lookInChildren ? source.GetComponentInChildren(type) : source.GetComponent(type);
}

namespace Characters
{
    public class ModelManager : MonoBehaviour
    {
        [SerializeField] private GameObject _loadedModel = null;
        [SerializeField] private DependencyInjection[] dependencyInjections = null;

        private void Awake() => InjectDependencyFormModel(_loadedModel);

        public void InjectDependencyFormModel(GameObject model)
        {
            foreach (var item in dependencyInjections)
                item.Apply(_loadedModel);
        }

        public void SetModel(GameObject model)
        {
            model.transform.SetParent(this.transform, false);
            InjectDependencyFormModel(_loadedModel = model);
        }
    }
}
