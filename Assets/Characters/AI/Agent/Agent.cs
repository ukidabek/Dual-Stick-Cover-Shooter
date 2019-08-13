using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public IMove Move { get; private set; }

    private void Awake()
    {
        var gameObject = transform.root;
        var properties = GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var item in properties)
            item.SetValue(this, gameObject.GetComponentInChildren(item.PropertyType));
    }
}
