using UnityEngine;
using Mechanic.BaseClasses;

[CreateAssetMenu(fileName = "Movement Settings.asset", menuName = "Settings/Movement Settings")]
public class NormalMovementControllerSettings : ScriptableObject
{
    [SerializeField] private float _speed = 5f;
    public float Speed { get => _speed; }
}
