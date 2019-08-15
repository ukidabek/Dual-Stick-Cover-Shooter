using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum Status
{
    Idle = 0,
    Alerted = 1,
    Chasing = 2
}

public interface ITargetProvider
{
    event Action<GameObject> OnTargetDetected;
    event Action<GameObject> OnTargetLost;
}

[RequireComponent(typeof(Animator))]
public class Agent : MonoBehaviour
{
    [Serializable]
    public class SensorResponse
    {
        public enum ResponseType { OnAll, OnAny }
        [SerializeField] private ResponseType type = ResponseType.OnAny;
        [SerializeField] private Status status;
        public Status Status { get => status; }

        [Serializable]
        public class SensorHandler
        {
            [SerializeField] private Sensor sensor = null;

            public bool IsSensorActive { get => sensor.Active; }
        }

        [SerializeField] private SensorHandler[] response = null;

        public bool IsTrigged
        {
            get
            {
                switch (type)
                {
                    case ResponseType.OnAll:
                        foreach (var item in response)
                            if (!item.IsSensorActive) return false;
                        return true;
                    case ResponseType.OnAny:
                        foreach (var item in response)
                            if (item.IsSensorActive) return true;
                        break;
                }
                return false;
            }
        }
    }

    [SerializeField] private Animator animator = null;
    [SerializeField] private SensorResponse[] statusTiggers = null;

    public IMove Move { get; private set; }

    public ITargetProvider [] TargetProviders { get; private set; }

    private void Awake()
    {
        Transform gameObject = transform.root;
        PropertyInfo[] properties = GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var item in properties)
        {
            if (item.PropertyType.IsArray)
            {
                Type type = item.PropertyType.GetElementType();
                Component[] list = gameObject.GetComponentsInChildren(type);
                Array array = Array.CreateInstance(type, list.Length);
                for (int i = 0; i < list.Length; i++)
                    array.SetValue(list[i], i);
                item.SetValue(this, array);
            }
            else
                item.SetValue(this, gameObject.GetComponentInChildren(item.PropertyType));
        }

        BaseAIState[] baseAIStates = animator.GetBehaviours<BaseAIState>();
        foreach (var item in baseAIStates)
            item.Initialize(this);
    }

    private void Update()
    {
        foreach (var item in statusTiggers)
            animator.SetBool(item.Status.ToString(), item.IsTrigged);
    }

    public void StatStatus(Status status, bool value = true)
    {
        animator.SetBool(status.ToString(), value);
    }
}
