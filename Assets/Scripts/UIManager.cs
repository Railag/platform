using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IManager
{

	[SerializeField] Text[] fields;

	[SerializeField] Slider progressBar;
	[SerializeField] Text progressText;

	[SerializeField] GameObject dialogPanel;
	[SerializeField] Text dialogText;

	#region IManager implementation

	public void initialization ()
	{
		dialogPanel.SetActive (false);
		dialogText.text = "";
	}

	#endregion

	public void DisplayItems (Dictionary<CollectableTrigger.CollectableType, float> items)
	{
		List<CollectableTrigger.CollectableType> types = CollectableTrigger.getCollectables ();

		for (int i = 0; i < fields.Length; i++) {
			fields [i].text = items [types [i]] + "x";
		}
	}

	public void DisplayLoading ()
	{
		//	if (!progressBar.gameObject.activeSelf)
		//		progressBar.gameObject.SetActive(true);

		//	progressBar.value = progress;

		if (!progressText.gameObject.activeSelf)
			progressText.gameObject.SetActive (true);
	}

	public void StopLoading ()
	{
		//progressBar.value = 0f;
		progressBar.gameObject.SetActive (false);
		progressText.gameObject.SetActive (false);
	}

	public void DisplayDialog (string text, float seconds)
	{
		dialogText.text = text;

		dialogPanel.SetActive (true);

		StartCoroutine (hideDialog (seconds));
	}

	IEnumerator hideDialog (float seconds)
	{
		yield return new WaitForSeconds (seconds);

		dialogPanel.SetActive (false);
	}
		
}