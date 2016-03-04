using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IManager {

	[SerializeField] Text[] fields;

	#region IManager implementation

	public void initialization ()
	{
		// TODO
	}

	#endregion

	public void DisplayItems (Dictionary<CollectableTrigger.CollectableType, float> items)
	{
		List<CollectableTrigger.CollectableType> types = CollectableTrigger.getCollectables ();

		for (int i = 0; i < fields.Length; i++) {
			fields [i].text = items [types [i]] + "x";
		}
	}
}