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
			break;
		case CollectableTrigger.CollectableType.Health:
			break;
		case CollectableTrigger.CollectableType.Lightning:
			break;
		case CollectableTrigger.CollectableType.ReverseTime:
			break;
		case CollectableTrigger.CollectableType.RightSpeed:
			break;
		}

		items [item] = count - 1;
	}

	private void DisplayItems() {
		Managers.ui().DisplayItems (items);
	}

}