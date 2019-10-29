using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters.Player
{
	public class PlayerSpawner : MonoBehaviour
	{
		private void OnEnable()
		{
			PlayerController.PlayerAdded += MovePlayer;
			if (PlayerController.Characters != null)
				foreach (PlayerController player in PlayerController.Characters)
					player.transform.position = GetPositon(player);
		}

		private void OnDestroy()
		{
			PlayerController.PlayerAdded -= MovePlayer;
		}

		private Vector3 GetPositon(PlayerController player)
		{
			return this.transform.position;
		}

		private void Reset()
		{
			gameObject.name = GetType().Name;
		}

		private void MovePlayer(PlayerController player)
		{
			player.transform.position = GetPositon(player);
		}
	}
}