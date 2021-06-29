using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LifeForm;

/// <summary>
/// seems to not be necessary, maybe required if UI considered
/// </summary>
namespace Interactions
{
	public class InteractableObject : MonoBehaviour
	{
		public Player player;
		public AInteraction[] interactions;
		void Start()
		{
			player = GameObject.Find("MainCharacter").GetComponent(typeof(Player)) as Player;
		}

		void Update()
		{
			/*float dist = Vector3.Distance(player.GetPos(), transform.position);
			foreach (Interaction i in interactions)
			{
				i.CheckInteraction(dist,player);
			}*/
		}
	}
}


