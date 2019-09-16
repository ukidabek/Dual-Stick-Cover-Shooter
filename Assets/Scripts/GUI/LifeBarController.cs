using Statistics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour
{
    //  TMP
    [SerializeField] private string currentHelthName = "CurrentHealth";

    [Space]
    private IDynamicStat stat = null;
    [SerializeField] private Slider slider = null;

    public void Register(CharacterController characterController)
    {
        IDynamicStat[] stats = characterController.transform.root.GetComponentsInChildren<IDynamicStat>();
        foreach (var item in stats)
            if (item.Name == currentHelthName)
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
