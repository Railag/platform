using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InvertoryManager : MonoBehaviour, IManager {

	private Dictionary<CollectableTrigger.CollectableType, float> items;
	
	#region IManager implementation

	public void initialization ()
	{
		items = new Dictionary<CollectableTrigger.CollectableType, float> ();
		List<CollectableTrigger.CollectableType> types = CollectableTrigger.getCollectables();
		foreach (CollectableTrigger.CollectableType type in types) {
			items.Add (type, 0);
		}
	}

	#endregion

	public void AddItem(CollectableTrigger.CollectableType item) {
		if (items.ContainsKey(item) ) {
			items [item]++;
		} else {
			items.Add (item, 1);
		}

		DisplayItems ();
	}

	public void ConsumeItem(CollectableTrigger.CollectableType item) {
		float count = items [item];

		if (count == 0) {
			return;
		}

		// TODO
		switch (item) {
		case CollectableTrigger.CollectableType.FlashSpeed:
			Managers.player ().SetSpeed (50.0f);
			break;
		case CollectableTrigger.CollectableType.Health:
			// becomes unbeatable
			Managers.player().Steel(10);
			break;
		case CollectableTrigger.CollectableType.Lightning:
			// becomes unbeatable, applies player electric animation, kills all enemies
			Managers.player ().Steel (7);
			Managers.player ().Lightning (7);
			break;
		case CollectableTrigger.CollectableType.ReverseTime:
			// takes user to position where he was ~ 10 seconds ago
			Managers.player ().BackInTime ();
			break;
		case CollectableTrigger.CollectableType.RightSpeed:
			Managers.player ().PushPlayerForward (20000f);
			break;
		}

		items [item] = count - 1;

		DisplayItems ();
	}

	private void DisplayItems() {
		Managers.ui().DisplayItems (items);
	}

}