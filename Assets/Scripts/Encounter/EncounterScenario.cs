using UnityEngine;

namespace Encounter
{
    [CreateAssetMenu(fileName = "NewScenario.asset", menuName = "Encounter/Scenario")]
    public class EncounterScenario : ScriptableObject
    {
        [SerializeField] private Act[] acts = null;
    }
}