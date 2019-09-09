using System;
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

        //  Tmp
        public event Action OnPlayed = null;
        private List<GameObject> instances = new List<GameObject>();

        private void Awake()
        {
            enabled = false;
        }

        public void Play(Vector3 position, float range)
        {
            enabled = true;
            //  Tmp
            {
                foreach (var item in actActor)
                {
                    Vector3 point = UnityEngine.Random.insideUnitCircle * range;
                    point.y = position.y;
                    Vector3 newPosition = point + position;
                    instances.Add(Instantiate(item, newPosition, Quaternion.identity));
                }
            }
            OnStart.Invoke();
        }

        public void Stop()
        {
            OnEnd.Invoke();
        }

        private void Update()
        {
            //  Tmp
            bool end = true;
            foreach (var item in instances)
                if (item.activeSelf)
                {
                    end = false;
                    break;
                }

            if (end)
            {
                enabled = false;
                OnPlayed?.Invoke();
            }
        }
    }
}