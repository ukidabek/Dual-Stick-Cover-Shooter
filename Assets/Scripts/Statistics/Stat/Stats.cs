using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Statistics
{
    public class Stats : MonoBehaviour
    {
        private Dictionary<string, IStat> statsDictionatry = new Dictionary<string, IStat>();

        private void Awake()
        {
            foreach (IStat stat in gameObject.GetComponentsInChildren<IStat>())
                statsDictionatry.Add(stat.Name, stat);
        }

        public IStat GetStat(string name)
        {
            if (statsDictionatry.TryGetValue(name, out IStat stat))
                return stat;
            else
                return null;
        }

        public IModifiableStat GetModifiableStat(string name)
        {
            IStat stat = GetStat(name);
            return (stat != null && stat is IModifiableStat) ? stat as IModifiableStat : null;
        }

        public IDynamicStat GetDynamicStat(string name)
        {
            IStat stat = GetStat(name);
            return (stat != null && stat is IDynamicStat) ? stat as IDynamicStat : null;

        }
    }
}