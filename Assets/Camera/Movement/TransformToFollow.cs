using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToFollow : MonoBehaviour, ICameraTargetPositionProvider
{
    private Bounds bounds = new Bounds();
    public Vector3 TargetPosition => bounds.center;

    private void Update()
    {
        bounds = new Bounds();
        foreach (var player in PlayerController.Players)
            bounds.Encapsulate(player.transform.position);
    }
}
