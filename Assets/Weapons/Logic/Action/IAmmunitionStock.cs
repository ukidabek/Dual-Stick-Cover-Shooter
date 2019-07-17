using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmmunitionStock
{
    int Counter { get; }
    int Stock { get; }
    event Action<int> OnStackChange;
}
