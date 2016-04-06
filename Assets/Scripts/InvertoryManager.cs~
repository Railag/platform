using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InvertoryManager : MonoBehaviour, IManager
{

	private Dictionary<CollectableTrigger.CollectableType, float> items;

	#region IManager implementation

	public void initialization ()
	{
		ResetItems ();
	}

	#endregion


	void LateUpdate ()
	{
		checkPressedKey ();
	}

	private void checkPressedKey ()
	{

		// invertory
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ConsumeItem (CollectableTrigger.CollectableType.Lightning);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ConsumeItem (CollectableTrigger.CollectableType.Health);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ConsumeItem (CollectableTrigger.CollectableType.FlashSpeed);
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			ConsumeItem (CollectableTrigger.CollectableType.ReverseTime);
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			ConsumeItem (CollectableTrigger.CollectableType.RightSpeed);
		}
	}

	public void AddItem (CollectableTrigger.CollectableType item)
	{
		if (items.ContainsKey (item)) {
			items [item]++;
		} else {
			items.Add (item, 1);
		}

		DisplayItems ();
	}


	public void ConsumeItem (CollectableTrigger.CollectableType item)
	{
		float count = items [item];

		if (count == 0) {
			return;
		}

		switch (item) {
		case CollectableTrigger.CollectableType.FlashSpeed:
			Managers.player ().SetSpeed (10.0f);
			break;
		case CollectableTrigger.CollectableType.Health:
			// becomes unbeatable
			Managers.player ().Steel (10);
			break;
		case CollectableTrigger.CollectableType.Lightning:
			// becomes unbeatable, applies player electric animation, kills all enemies
			Managers.player ().SteelWithNoEffect (7);
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

	private void DisplayItems ()
	{
		Managers.ui ().DisplayItems (items);
	}

	public Dictionary<CollectableTrigger.CollectableType, float> GetItems ()
	{
		return items;
	}

	public void SetItems (Dictionary<CollectableTrigger.CollectableType, float> items)
	{
		this.items = items;
		DisplayItems ();
	}

	public void ResetItems ()
	{
		items = new Dictionary<CollectableTrigger.CollectableType, float> ();
		List<CollectableTrigger.CollectableType> types = CollectableTrigger.getCollectables ();
		foreach (CollectableTrigger.CollectableType type in types) {
			items.Add (type, 0);
		}
	}

}