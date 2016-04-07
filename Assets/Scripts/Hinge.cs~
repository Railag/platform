using UnityEngine;
using System.Collections;

public class Hinge : MonoBehaviour
{
	[SerializeField] Sprite activeSprite;
	private Sprite inactiveSprite;

	[SerializeField] float seconds = 3.0f;

	private bool active = false;

	void Start ()
	{
		inactiveSprite = GetComponent<SpriteRenderer> ().sprite;
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerMovement> ()) {
			Managers.player ().HitPlayer ();

			if (active)
				return;

			active = true;
			GetComponent<SpriteRenderer> ().sprite = activeSprite;

			StartCoroutine (MoveBack ());
		}
	}

	IEnumerator MoveBack ()
	{
		yield return new WaitForSeconds (seconds);

		active = false;
		GetComponent<SpriteRenderer> ().sprite = inactiveSprite;
	}
}
