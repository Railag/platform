using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IManager {

	[SerializeField] Text[] fields;

	[SerializeField] Slider progressBar;
	[SerializeField] Text progressText;

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

	public void DisplayLoading() {
	//	if (!progressBar.gameObject.activeSelf)
	//		progressBar.gameObject.SetActive(true);

	//	progressBar.value = progress;

		if (!progressText.gameObject.activeSelf)
			progressText.gameObject.SetActive(true);
	}

	public void StopLoading() {
		//progressBar.value = 0f;
		progressBar.gameObject.SetActive(false);
		progressText.gameObject.SetActive(false);
	}
		
}