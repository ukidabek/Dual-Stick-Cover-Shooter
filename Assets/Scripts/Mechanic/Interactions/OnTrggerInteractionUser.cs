using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrggerInteractionUser : MonoBehaviour
{
    [SerializeField] private Interaction _interaction = null;
    private List<Interaction> interactions = new List<Interaction>();

    private void OnTriggerEnter(Collider other)
    {
        _interaction = other.gameObject.GetComponent<Interaction>();
        //if (interaction != null)
        //    interactions.Add(interaction);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_interaction == other.gameObject.GetComponent<Interaction>())
            _interaction = null;
        //if (interaction != null)
        //    interactions.Remove(interaction);
    }

    public void Use()
    {
        if (_interaction != null)
            _interaction.Use(transform.root.gameObject);
    }
}
