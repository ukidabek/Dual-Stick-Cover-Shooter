using System.Collections.Generic;
using UnityEngine;

namespace Statistics
{
    public class Stats : MonoBehaviour
    {
        private readonly Dictionary<string, IStat> statsDictionary = new Dictionary<string, IStat>();

        private void Awake()
        {
            foreach (IStat stat in gameObject.GetComponentsInChildren<IStat>())
                statsDictionary.Add(stat.Name, stat);
        }

        public IStat GetStat(string name)
        {
            if (statsDictionary.TryGetValue(name, out IStat stat))
                return stat;
            else
                return null;
        }

        public IModifiableStat GetModifiableStat(string name)
        {
            IStat stat = GetStat(name);
            return stat is IModifiableStat modifiableStat ? modifiableStat : null;
        }

        public IDynamicStat GetDynamicStat(string name)
        {
            IStat stat = GetStat(name);
            return stat is IDynamicStat dynamicStat ? dynamicStat : null;
        }
    }
}