using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private static List<CharacterController> characters = new List<CharacterController>();
    public static ReadOnlyCollection<CharacterController> Characters = null;

    protected virtual void Awake()
    {
        if (characters == null) Characters = new ReadOnlyCollection<CharacterController>(characters);
    }

    protected virtual void Start()
    {
        Add(this);
    }

    protected virtual void Add(CharacterController character)
    {
        characters.Add(this);
    }

    protected virtual void Remove(CharacterController character)
    {
        characters.Remove(this);
    }

    protected virtual void OnDisable()
    {
        Remove(this);
    }

    protected virtual void OnDestroy()
    {
        Remove(this);
    }

}
