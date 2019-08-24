using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject game = null;

    private void Awake()
    {
        Spawm();
    }

    void Spawm()
    {
        Instantiate(game, transform.position, transform.rotation).SetActive(true);
        Invoke("Spawm", 1f);
    }
}
