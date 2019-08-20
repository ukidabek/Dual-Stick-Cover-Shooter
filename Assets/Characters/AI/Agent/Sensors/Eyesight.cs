using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyesight : Sensor
{
    [SerializeField] private float rande = 3f;
    private List<Characters.Player.PlayerController> Players = new List<Characters.Player.PlayerController>();

    protected override bool Scan()
    {
        Players.Clear();
        if(Characters.Player.PlayerController.Players != null)
        {
            foreach (var item in Characters.Player.PlayerController.Players)
            {
                if (Vector3.Distance(item.transform.position, transform.position) <= rande)
                {
                    TargetDetected(item.gameObject);
                    Players.Add(item);
                }
                else
                    TargetLost(item.gameObject);
            }
        }

        return Players.Count > 0;
    }
}
