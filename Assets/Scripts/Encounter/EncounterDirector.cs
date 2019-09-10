using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Encounter
{
    public class EncounterDirector : MonoBehaviour
    {
        public UnityEvent OnStart = new UnityEvent();
        public UnityEvent OnEnd = new UnityEvent();

        [SerializeField] private float range = 1f;
        [SerializeField] private Transform[] spawnPoints = null;

        [SerializeField] private int index = 0;
        [SerializeField] private Act[] acts = null;

        private void Awake()
        {
            foreach (var item in acts)
                item.OnEnd.AddListener(GoToNext);
        }

        private void GoToNext()
        {
            if (index == acts.Length - 1)
            {
                OnEnd.Invoke();
            }
            else
                acts[++index].Play(transform.position, range);
        }

        public void Play()
        {
            OnStart.Invoke();
            acts[index = 0].Play(transform.position, range);
        }

        private void OnValidate()
        {
            for (int i = 0; i < acts.Length; i++)
                acts[i].gameObject.name = string.Format("{0} - {1}", typeof(Act).Name, (i + 1).ToString());
        }

        private void OnDrawGizmos()
        {
            if (spawnPoints.Length == 0)
                Gizmos.DrawWireSphere(transform.position, range);
            else
                foreach (var item in spawnPoints)
                    Gizmos.DrawWireSphere(item.transform.position, .25f);
        }

        private void Reset()
        {
            gameObject.name = this.GetType().Name;
        }
    }
}