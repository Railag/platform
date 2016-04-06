using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MobileTouchSprite : MonoBehaviour
{

	[SerializeField] CollectableTrigger.CollectableType type = CollectableTrigger.CollectableType.None;

	private float radius = 5.5f;

	private bool locked = false;

	void LateUpdate ()
	{
		#if !UNITY_STANDALONE && !UNITY_WEBPLAYER
		if (Input.touchCount > 0 && !locked) {
			Touch touch = Input.GetTouch (0);
			Vector2 position = touch.position;
			Vector2 viewportPoint = Camera.main.WorldToViewportPoint (position);
			Vector2 spritePos = Camera.main.WorldToViewportPoint (transform.position);
			float distance = Vector2.Distance (viewportPoint, spritePos);
			if (distance < radius) {
				Managers.invertory ().ConsumeItem (type);
				locked = true;
				StartCoroutine (Unlock ());
			}
		}

		#endif


	}

	IEnumerator Unlock ()
	{
		yield return new WaitForSeconds (0.2f);

		locked = false;
	}
}
