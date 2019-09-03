using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class SetupCallback : UnityEvent<float> { }

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeToDeactivate = float.MinValue;

    public SetupCallback SetupSepeed = new SetupCallback();
    public SetupCallback SetupDamage = new SetupCallback();

    public void Setup(float damage, float range)
    {
        timeToDeactivate = range / speed;
        SetupSepeed.Invoke(speed);
        SetupDamage.Invoke(damage < 0 ? damage : damage * -1);
    }

    private void Update()
    {
        if (timeToDeactivate <= 0f)
            gameObject.SetActive(false);
        else
            timeToDeactivate -= Time.deltaTime;
    }
}