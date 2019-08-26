using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAiState : BaseAIState
{
    [SerializeField] private float wanderRange = 1f;
    [SerializeField] private float interval = 1f;

    private Vector3 startPosition = Vector3.zero;
    private Coroutine randomizeWanderPointCoroutine = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        startPosition = Transform.position;
        randomizeWanderPointCoroutine = agent.StartCoroutine(RandomizeWanderPoint());
    }

    private IEnumerator RandomizeWanderPoint()
    {
        while(true)
        {
            Vector2 vector = Random.insideUnitCircle * wanderRange;
            Vector3 destination = startPosition + new Vector3(vector.x, startPosition.y, vector.y);
            Debug.Log(destination);
            agent.Move.Set(destination);
            yield return new WaitForSeconds(interval);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        agent.StopCoroutine(randomizeWanderPointCoroutine);
    }
}
