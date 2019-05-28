using System.Collections.Generic;
using UnityEngine;

public class AnalogInputCommandReciver : MonoBehaviour
{
    [SerializeField] private List<AnalogInputStatusReciver> _analogInputStatusRecivers = new List<AnalogInputStatusReciver>();
    public void SetInput(int index, Vector3 input)
    {
        _analogInputStatusRecivers[index].SetStatus(input);
    }
    private void Reset()
    {
        gameObject.name = GetType().Name;
    }
}
