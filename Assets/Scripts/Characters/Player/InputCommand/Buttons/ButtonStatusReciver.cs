using UnityEngine;
using UnityEngine.Events;

public class ButtonStatusReciver : MonoBehaviour
{
    [SerializeField] private bool _status = false;
    [SerializeField] private bool _oldStatus = false;
    public bool Status { get => _status; set => _status = value; }

    [SerializeField] private UnityEvent OnDown = new UnityEvent();
    [SerializeField] private UnityEvent OnHold = new UnityEvent();
    [SerializeField] private UnityEvent OnUp = new UnityEvent();

    private void Update()
    {
        if (_status && !_oldStatus) OnDown.Invoke();
        if (_status && _oldStatus) OnHold.Invoke();
        if (!_status && _oldStatus) OnUp.Invoke();

        _oldStatus = _status;
    }
}
