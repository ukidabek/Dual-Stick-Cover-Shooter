using UnityEngine;
using Mechanic.BaseClasses;

public class Using : MechanicWithSettings<UsingSettings>, IUse
{
    private GameObject _rootObject = null;
    [SerializeField] private Interaction interaction = null;
    private RaycastHit _hit = new RaycastHit();

    protected override void Awake()
    {
        base.Awake();
        interaction = null;
        _rootObject = GetRoot(gameObject);
    }

    private GameObject GetRoot(GameObject gameObject)
    {
        if (gameObject.transform.parent != null)
            return GetRoot(gameObject.transform.parent.gameObject);
        else return gameObject;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, transform.forward * settings.Distance, Color.yellow);
#endif
        if (Physics.Raycast(ray, out _hit, settings.Distance))
        {
            var interaction = _hit.collider.gameObject.GetComponent<Interaction>();
            if (this.interaction != interaction)
            {
                if (interaction == null)
                    this.interaction.Hide();

                this.interaction = interaction;

                if (this.interaction != null)
                    this.interaction.Show();
            }
        }
#if UNITY_EDITOR
        if (interaction != null)
            Debug.DrawLine(transform.position, _hit.point, Color.green);
#endif
    }

    public void Use()
    {
        if (interaction != null)
            interaction.Use(_rootObject);
    }

    public void Cancel()
    {
        if (interaction != null)
            interaction.Leave();
    }
}
