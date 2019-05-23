using UnityEngine;
using Mechanic.BaseClasses;

[CreateAssetMenu(fileName = "Using Settings.asset", menuName = "Settings/Using Settings")]
public class UsingSettings : ScriptableObject
{
    [SerializeField] private float _distance = 5f;
    public float Distance { get { return _distance; } }
}
