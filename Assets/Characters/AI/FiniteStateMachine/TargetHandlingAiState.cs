using System.Collections.Generic;
using UnityEngine;

public class TargetHandlingAiState : BaseAIState
{
    [SerializeField] protected List<GameObject> targets = new List<GameObject>();

    public override void Initialize(Agent agent)
    {
        base.Initialize(agent);
        foreach (var item in agent.TargetProviders)
        {
            item.OnTargetDetected += AddTarget;
            item.OnTargetLost += RemoveTarget;
        }
    }

    private void AddTarget(GameObject gameObject)
    {
        if (!targets.Contains(gameObject))
            targets.Add(gameObject);
    }

    private void RemoveTarget(GameObject gameObject)
    {
        if (targets.Contains(gameObject))
            targets.Remove(gameObject);
    }
}
