using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Statistics
{
    public class ConstStatModifier : MonoBehaviour
    {
        [SerializeField, Range(0f, 5f)] float modifier = 1f;

        public OnStatUpdate OnStatRecalculated = new OnStatUpdate();

        public void OverrideStat(float stat)
        {
            OnStatRecalculated.Invoke(stat * modifier);
        }
    }
}