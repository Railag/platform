using UnityEngine;
using System.Collections;

public class OpenTrigger : Trigger {
	[SerializeField] private GameObject _objectToHide;

	private bool hidden = false;

	private bool locked = false;

	private bool introPassed = false;

	private float distance = 0f;

	void Start() {
		distance = _objectToHide.GetComponent<Renderer> ().bounds.size.y;
	}

	override
	public void PlayerCollide() {

		if (locked)
			return;

		if (!introPassed)
			Managers.player ().IntroCamera (_objectToHide.transform.position);

		float y = hidden ? distance : -distance;
		Vector3 movement = new Vector3 (0, y, 0);

		iTween.MoveBy (_objectToHide, movement, 2f);

		Managers.player().

		StartCoroutine (Unlock (2f));

		locked = true;

		hidden = !hidden;

		introPassed = true;
	}

	IEnumerator Unlock(float seconds) {
		yield return new WaitForSeconds (seconds);

		locked = false;
	}
}
