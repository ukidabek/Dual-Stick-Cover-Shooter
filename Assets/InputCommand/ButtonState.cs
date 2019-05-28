using UnityEngine;

public class ButtonState : MonoBehaviour
{
    [SerializeField] private bool _status = false;
    public bool Status { get => _status; set => _status = value; }

}