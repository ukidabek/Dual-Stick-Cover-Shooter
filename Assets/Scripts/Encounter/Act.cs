using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Encounter
{
    public class Act : MonoBehaviour
    {
        public UnityEvent OnStart = new UnityEvent();
        public UnityEvent OnEnd = new UnityEvent();

        [SerializeField] private GameObject[] actActor = null;

        private List<GameObject> instances = new List<GameObject>();

        private void Awake()
        {
            enabled = false;
        }

        public void Play(Vector3 basePosition, float range)
        {
#if UNITY_EDITOR
            Debug.LogFormat("<color=#008000ff>{0}</color> form {1} started!", gameObject.name, transform.parent.name);
#endif
            enabled = true;
            foreach (var item in actActor)
            {
                Vector3 point = Random.insideUnitCircle * range;
                point.y = basePosition.y;
                Vector3 newPosition = point + basePosition;

                //  Tmp ---- To be replaced by pool mechanics
                GameObject instance = Instantiate(item, newPosition, Quaternion.identity);
                AddOrGet(instance).OnDisabledCallback += OnDisabledCallback;
                instances.Add(instance);

            }

            OnStart.Invoke();
        }

        private void OnDisabledCallback(GameObject gameObject)
        {
            AddOrGet(gameObject).OnDisabledCallback -= OnDisabledCallback;
            instances.Remove(gameObject);
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