using UnityEngine;

public class AnalogInputStatus : MonoBehaviour
{
    [SerializeField] private Vector3 _input = Vector3.zero;
    public Vector3 Input
    {
        get
        {
            _isDirty = false;
            return _input;
        }
        set => _isDirty = ValidateVector(ref _input, value);
    }

    [SerializeField] private bool _isDirty = true;
    public bool IsDirty { get => _isDirty; }
    private bool ValidateVector(ref Vector3 current, Vector3 input)
    {
        if (current != input)
        {
            current = input;
            return true;
        }
        return false;
    }

    public static implicit operator Vector3(AnalogInputStatus inputHandler)
    {
        return inputHandler.Input;
    }

#if UNITY_EDITOR
    private string _defaultName = string.Empty;

    private void Awake()
    {
        _defaultName = gameObject.name;
    }

    private void Update()
    {
        gameObject.name = string.Format("{0} {1}", _defaultName, _input.ToString("0.00"));
    }
#endif
}
