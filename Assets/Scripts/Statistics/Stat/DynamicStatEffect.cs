using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Statistics
{
    public abstract class DynamicStatEffect : MonoBehaviour
    {
        protected IDynamicStat dynamicStat = null;
        protected virtual void Awake()
        {
            dynamicStat = GetComponent<IDynamicStat>();
            if(dynamicStat != null)
            {
                dynamicStat.OnStatEmptyCallback.AddListener(OnStatEmpty);
                dynamicStat.OnStatFullCallback.AddListener(OnStatFull);
                dynamicStat.OnStatUpdateCallback.AddListener(OnStatUpdate);
            }
        }

        protected abstract void OnStatFull();
        protected abstract void OnStatEmpty();
        protected abstract void OnStatUpdate(float value);
    }
}