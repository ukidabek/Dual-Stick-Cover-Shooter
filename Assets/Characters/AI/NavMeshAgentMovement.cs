﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentMovement : MonoBehaviour, IMove
{
    [SerializeField] private NavMeshAgent navMeshAgent = null;
    public bool OnPosition => navMeshAgent.remainingDistance < .1f;

    public void MoveToPosition(Vector3 position)
    {
        navMeshAgent.SetDestination(position);
    }

    private void Reset()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }
}
