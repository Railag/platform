using UnityEngine;
using System.Collections;

public class OpenTrigger : Trigger {
	[SerializeField] private GameObject _objectToHide;

	private bool hidden = false;

	private bool locked = false;

	private float distance = 0f;

	void Start() {
		distance = _objectToHide.GetComponent<Renderer> ().bounds.size.y;
	}

	override
	public void PlayerCollide() {

		if (locked)
			return;

		float y = hidden ? distance : -distance;
		Vector3 movement = new Vector3 (0, y, 0);

		iTween.MoveBy (_objectToHide, movement, 2f);
		StartCoroutine (Unlock (2f));

		locked = true;

		hidden = !hidden;
	}

	IEnumerator Unlock(float seconds) {
		yield return new WaitForSeconds (seconds);

		locked = false;
	}
}
