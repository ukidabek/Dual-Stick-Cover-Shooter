using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    Vector3 MoveInput { get; set; }
}
public interface IAim
{
    Vector3 MoveInput { get; set; }
}

public interface IAimToggle
{
    bool Activate { get; set; }
}

public class PlayerController : MonoBehaviour
{
    private IMove[] _movementHandlers = null;
    private IAim[] _aimHandlers = null;
    private IAimToggle[] _aimToggles = null; 

    private void Awake()
    {
        _movementHandlers = gameObject.GetComponentsInChildren<IMove>();
        _aimHandlers = gameObject.GetComponentsInChildren<IAim>();
        _aimToggles = gameObject.GetComponentsInChildren<IAimToggle>();
    }

    public void Move(Vector3 input)
    {
        for (int i = 0; i < _movementHandlers.Length; i++)
            _movementHandlers[i].MoveInput = input;
    }

    public void Aim(Vector3 input)
    {
        for (int i = 0; i < _aimHandlers.Length; i++)
            _aimHandlers[i].MoveInput = input;
    }

    public void Aim(bool activate)
    {
        for (int i = 0; i < _aimToggles.Length; i++)
            _aimToggles[i].Activate = activate;
    }
}
