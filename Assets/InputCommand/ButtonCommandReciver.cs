using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCommandReciver : MonoBehaviour
{
    [SerializeField] private List<ButtonStatusReciver> _buttonStatusRecivers = new List<ButtonStatusReciver>();

    public void SetStatus(int index, bool status)
    {
        _buttonStatusRecivers[index].Status = status;
    }

    private void Reset()
    {
        gameObject.name = GetType().Name;
    }
}
