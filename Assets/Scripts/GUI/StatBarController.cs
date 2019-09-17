using Statistics;
using UnityEngine;
using UnityEngine.UI;

public class StatBarController : MonoBehaviour
{
    [SerializeField] private Type dynamicStatType = new Type();

    [Space]
    private IDynamicStat stat = null;
    [SerializeField] private Slider slider = null;

    public void Register(CharacterController characterController)
    {
        IDynamicStat[] stats = characterController.transform.root.GetComponentsInChildren<IDynamicStat>();
        foreach (var item in stats)
            if (item.Name == dynamicStatType)
            {
                (stat = item).OnStatUpdateCallback.AddListener(OnStatUpdateCallback);
                break;
            }
    }

    private void OnStatUpdateCallback(float value)
    {
        slider.value = value / stat.MaxValue;
    }
}
