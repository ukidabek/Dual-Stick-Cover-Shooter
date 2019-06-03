using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class OnTrggerInteractionUser : MonoBehaviour
{
    [SerializeField] private SphereCollider _sphereCollider = null;
    [SerializeField] private Interaction _interaction = null;
    private List<Interaction> interactions = new List<Interaction>();

    [SerializeField] private bool _useAngle = false;  
    [SerializeField, HideInInspector] private float _interactionShowAngle = 40f;

    private Vector3 _targetDirection = Vector3.zero;
    private float _angle = 0;

    private void OnTriggerEnter(Collider other)
    {
        var interaction = other.gameObject.GetComponent<Interaction>();
        if (interaction != null)
            interactions.Add(interaction);
    }

    private void OnTriggerExit(Collider other)
    {
        var interaction = other.gameObject.GetComponent<Interaction>();
        if (interaction != null)
        {
            if (_interaction == interaction)
                interaction.Hide();
            interactions.Remove(interaction);
            if (interactions.Count == 0)
                _interaction = null;
        }
    }

    private void Reset()
    {
        _sphereCollider = transform.root.GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (interactions.Count > 0)
        {
            float distance = Vector3.Distance(transform.root.transform.position, interactions[0].transform.position);
            var closestInteraction = interactions[0];

            for (int i = 1; i < interactions.Count; i++)
            {
                float tmpDistance = Vector3.Distance(transform.root.transform.position, interactions[i].transform.position);
                if (tmpDistance < distance)
                {
                    distance = tmpDistance;
                    closestInteraction = interactions[i];
                }
            }

            if (closestInteraction != _interaction)
            {
                if(!_useAngle)
                {
                    _interaction?.Hide();
                    closestInteraction.Show();
                }
                _interaction = closestInteraction;
            }

            if (_useAngle && _interaction != null)
            {
                _targetDirection = _interaction.transform.position - transform.root.transform.position;
                _angle = Vector3.Angle(_targetDirection, transform.root.transform.forward);
                if (_angle <= (_interactionShowAngle / 2f))
                    _interaction.Show();
                else
                    _interaction.Hide();
            }
        }
    }

    public void Use()
    {
        if (_interaction != null)
            _interaction.Use(transform.root.gameObject);
    }

    private void OnDrawGizmos()
    {
        if(_useAngle)
        {
            Quaternion rotation = Quaternion.AngleAxis(_interactionShowAngle, Vector3.up);
            Vector3 localPosition = rotation * (Vector3.zero + Vector3.forward * _sphereCollider.radius);
            Vector3 position = transform.root.TransformPoint(localPosition);
            Debug.DrawLine(transform.root.transform.position, position, Color.green);
         
            rotation = Quaternion.AngleAxis(-_interactionShowAngle, Vector3.up);
            localPosition = rotation * (Vector3.zero + Vector3.forward * _sphereCollider.radius);
            position = transform.root.TransformPoint(localPosition);
            Debug.DrawLine(transform.root.transform.position, position, Color.green);
        }
    }
}
