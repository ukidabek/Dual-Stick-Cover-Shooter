using UnityEngine;

public class ButtonState : MonoBehaviour
{
    [SerializeField] private bool _status = false;
    public bool Status { get => _status; set => _status = value; }

#if UNITY_EDITOR
    private string _defaultName = string.Empty;

    private void Awake()
    {
        _defaultName = gameObject.name;
    }

    private void Update()
    {
        gameObject.name = string.Format("{0} {1}", _defaultName, _status.ToString());
    }
#endif
}