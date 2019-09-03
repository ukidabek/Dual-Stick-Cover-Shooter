using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerIDSetter
{
    int PlayerID { get; set; }
}

public class InputsCommandManager : MonoBehaviour
{
    [SerializeField] private int _playerID = 0;

    private void Awake()
    {
        foreach (var item in GetComponentsInChildren<IPlayerIDSetter>())
            item.PlayerID = _playerID;
    }
}
