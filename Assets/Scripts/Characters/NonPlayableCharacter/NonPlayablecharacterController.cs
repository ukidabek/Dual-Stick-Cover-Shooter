using AI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class NonPlayablecharacterController : CharacterController
{
    // TMP
    private static Dictionary<int, NonPlayablecharacterController> nonPlayablecharacterDictionary = new Dictionary<int, NonPlayablecharacterController>();
    public static ReadOnlyDictionary<int, NonPlayablecharacterController> NonPlayablecharacterDictionary { get; private set; }

    private static int lastID = 0;

    private static void Register(NonPlayablecharacterController controller)
    {
        if (!nonPlayablecharacterDictionary.ContainsKey(controller.characterId))
            nonPlayablecharacterDictionary.Add(controller.characterId, controller);
    }

    private static void Remove(NonPlayablecharacterController controller)
    {
        if (nonPlayablecharacterDictionary.ContainsKey(controller.characterId))
            nonPlayablecharacterDictionary.Remove(controller.characterId);
    }

    [SerializeField] private int characterId = 0;
    public int CharacterId { get => characterId; }
    [SerializeField] private AIAgent agent = null;
    public AIAgent Agent { get => agent; }

    protected override void Awake()
    {
        base.Awake();
        if (NonPlayablecharacterDictionary == null) NonPlayablecharacterDictionary = new ReadOnlyDictionary<int, NonPlayablecharacterController>(nonPlayablecharacterDictionary);
        characterId = lastID++;
    }

    private void OnEnable()
    {
        Register(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
