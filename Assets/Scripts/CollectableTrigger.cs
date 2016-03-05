﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectableTrigger : Trigger {
	[SerializeField] CollectableType type;

	private static List<CollectableType> collectables; 

	public static List<CollectableType> getCollectables() {
		if (collectables == null) {
			collectables = new List<CollectableType> ();
			collectables.Add (CollectableType.Lightning);
			collectables.Add (CollectableType.Health);
			collectables.Add (CollectableType.FlashSpeed);
			collectables.Add (CollectableType.ReverseTime);
			collectables.Add (CollectableType.RightSpeed);
		}

		return collectables;
	}

	public enum CollectableType {
		None,
		Lightning,
		Health,
		FlashSpeed,
		ReverseTime,
		RightSpeed
	}

	override
	public void PlayerCollide() {
		CollectItem ();
		Destroy (gameObject);
	}
		
	private void CollectItem() {
		Managers.invertory ().AddItem (type);
	}
		
}