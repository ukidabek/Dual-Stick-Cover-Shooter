using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Encounter
{
    public class Act : MonoBehaviour
    {
        public UnityEvent OnStart = new UnityEvent();
        public UnityEvent OnEnd = new UnityEvent();

        [SerializeField] private NonPlayableCharacterController[] actActor = null;
        private Pool<NonPlayableCharacterController>[] actorsPool = null;
        private List<ActorLifeCycleObserver> instances = new List<ActorLifeCycleObserver>();

        private void Awake()
        {
            actorsPool = new Pool<NonPlayableCharacterController>[actActor.Length];
            for (int i = 0; i < actActor.Length; i++)
                actorsPool[i] = new Pool<NonPlayableCharacterController>(actActor[i], null, 2);
        }

        private IEnumerator ActStatyCoroutine(Vector3 basePosition, float range)
        {
            yield return new WaitForEndOfFrame();
            foreach (var item in actorsPool)
            {
                Vector3 point = Random.insideUnitCircle * range;
                point.y = basePosition.y;
                Vector3 newPosition = point + basePosition;

                NonPlayableCharacterController instance = item.Get();
                instance.transform.position = newPosition;
                instance.gameObject.SetActive(true);
                ActorLifeCycleObserver observer = AddOrGet(instance.gameObject);
                observer.OnDisabledCallback += OnDisabledCallback;
                instances.Add(observer);
            }
        }

        public void Play(Vector3 basePosition, float range)
        {
#if UNITY_EDITOR
            Debug.LogFormat("<color=#008000ff>{0}</color> form {1} started!", gameObject.name, transform.parent.name);
#endif

            instances.Clear();
            // Waits until the end of the frame to avoid errors with activating / deactivating an GameObject in the same frame.
            StartCoroutine(ActStatyCoroutine(basePosition, range));
            OnStart.Invoke();
        }

        private void OnDisabledCallback(GameObject gameObject)
        {
            ActorLifeCycleObserver observer = AddOrGet(gameObject);
            observer.OnDisabledCallback -= OnDisabledCallback;
            instances.Remove(observer);
            if (instances.Count == 0)
                Stop();
        }

        public void Stop()
        {
#if UNITY_EDITOR
            Debug.LogFormat("<color=#008000ff>{0}</color> form {1} played!", gameObject.name, transform.parent.name);
#endif
            enabled = false;
            OnEnd.Invoke();
        }

        public ActorLifeCycleObserver AddOrGet(GameObject gameObject)
        {
            ActorLifeCycleObserver instance = gameObject.GetComponent<ActorLifeCycleObserver>();
            return instance == null ? gameObject.AddComponent<ActorLifeCycleObserver>() : instance;
        }
    }
}