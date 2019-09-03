using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TargetManager : MonoBehaviour, ITargetProvider
{
    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    public ReadOnlyCollection<GameObject> Targets { get; private set; }

    private void Awake()
    {
        Targets = new ReadOnlyCollection<GameObject>(targets);
        ISensor[] sensors = gameObject.GetComponentsInChildren<ISensor>();
        foreach (var item in sensors)
        {
            item.OnTargetDetected += OnTargetDetected;
            item.OnTargetLost += OnTargetLost;
        }
    }

    private void OnTargetLost(GameObject obj)
    {
        if (!targets.Contains(obj))
            targets.Add(obj);
    }

    private void OnTargetDetected(GameObject obj)
    {
        if (targets.Contains(obj))
            targets.Remove(obj);
    }
}
