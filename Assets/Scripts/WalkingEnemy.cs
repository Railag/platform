using UnityEngine;
using System.Collections;

public class WalkingEnemy : MonoBehaviour {

	[SerializeField]
	private float speed = 3f;

	private GameObject lightningInstance;

	private float direction = 1f;

	private Rigidbody2D rigidBody;

	private int stoppedCount = 0;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		// count blocked time without velocity
		if (Mathf.Abs(rigidBody.velocity.x) < 1f) {
			stoppedCount++;
		}

		// change direction if no movement (blocked)
		if (stoppedCount >= 4) {
			ChangeDirection ();
			stoppedCount = 0;
		}

		rigidBody.velocity = new Vector2 (speed * direction, rigidBody.velocity.y);
		transform.localScale = new Vector3 (-direction, 1, 1);
	}

	public void ChangeDirection() {
		direction *= -1f;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.GetComponent<PlayerMovement> ()) {
			bool reflect = Managers.player ().HitPlayer ();
			if (reflect && lightningInstance == null) {
				int contactsCount = collision.contacts.Length;

				ContactPoint2D contact;
				if (contactsCount > 1)
					contact = collision.contacts[contactsCount / 2];
				else
					contact = collision.contacts[0];
				Vector2 orthogonalVector = contact.point;
				float collisionAngle = Vector3.Angle (collision.transform.position, collision.rigidbody.velocity);
				Quaternion rotation = Quaternion.Euler (collisionAngle, -90f, 90f);
				Vector3 position = (collision.transform.position + transform.position) * 0.5f;
				lightningInstance = Instantiate (Managers.enemy().GetSparkPrefab(), position, rotation) as GameObject;
				StartCoroutine (Death (0.3f));
			}
		}
	}

	IEnumerator Death(float seconds) {

		iTween.FadeTo (gameObject, 0f, seconds);

		yield return new WaitForSeconds(seconds);

		Destroy (gameObject);
		Destroy (lightningInstance);
	}
}