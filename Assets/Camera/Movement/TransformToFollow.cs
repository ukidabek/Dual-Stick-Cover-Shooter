using Characters.Player;
using UnityEngine;

public class TransformToFollow : MonoBehaviour, ICameraTargetPositionProvider
{
    private Bounds bounds = new Bounds();
    public Vector3 TargetPosition => PlayerController.Players.Count == 1 ? PlayerController.Players[0].transform.position : bounds.center;

    private void Update()
    {
        bounds = new Bounds();
        foreach (var player in PlayerController.Players)
            bounds.Encapsulate(player.transform.position);
    }
}
