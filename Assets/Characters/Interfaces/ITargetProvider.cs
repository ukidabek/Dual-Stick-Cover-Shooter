using System.Collections.ObjectModel;
using UnityEngine;

public interface ITargetProvider
{
    ReadOnlyCollection<GameObject> Targets { get; }
}
