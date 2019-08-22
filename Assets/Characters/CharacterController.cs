using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    private static List<CharacterController> characters = new List<CharacterController>();
    public static ReadOnlyCollection<CharacterController> Characters = null;

    public IMove Move { get; private set; }
    public ILook Look { get; private set; }
    public IWeapon Weapon { get; private set; }
    public IAim Aim { get; private set; }
    public IUse Use { get; private set; }

    protected void InitializeInterfaces()
    {
        Transform gameObject = transform.root;
        List<PropertyInfo> properties = new List<PropertyInfo>();
        Type type = GetType(), monoBehaviourType = typeof(MonoBehaviour);

        while (type != monoBehaviourType)
        {
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo item in propertyInfos)
                if (item.PropertyType.IsInterface)
                    properties.Add(item);

            type = type.BaseType;
        }

        foreach (var item in properties)
        {
            if (item.PropertyType.IsArray)
            {
                Type elementType = item.PropertyType.GetElementType();
                Component[] list = gameObject.GetComponentsInChildren(elementType);
                Array array = Array.CreateInstance(elementType, list.Length);
                for (int i = 0; i < list.Length; i++)
                    array.SetValue(list[i], i);
                item.SetValue(this, array);
            }
            else
                item.SetValue(this, gameObject.GetComponentInChildren(item.PropertyType));
        }
    }

    protected virtual void Awake()
    {
        if (characters == null) Characters = new ReadOnlyCollection<CharacterController>(characters);
        InitializeInterfaces();
    }

    protected virtual void Start()
    {
        Add(this);
    }

    protected virtual void Add(CharacterController character)
    {
        characters.Add(this);
    }

    protected virtual void Remove(CharacterController character)
    {
        characters.Remove(this);
    }

    protected virtual void OnDisable()
    {
        Remove(this);
    }

    protected virtual void OnDestroy()
    {
        Remove(this);
    }

}
