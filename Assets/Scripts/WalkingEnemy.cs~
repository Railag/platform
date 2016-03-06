using UnityEngine;
using System.Collections;

public class WalkingEnemy : MonoBehaviour {

	[SerializeField]
	private float speed = 3000f;

	private float direction = 1f;

	private Rigidbody2D rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		rigidBody.velocity = new Vector2 (speed * direction * Time.deltaTime, rigidBody.velocity.y);
		transform.localScale = new Vector3 (-direction, 1, 1);
	}

	public void ChangeDirection() {
		direction *= -1f;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.GetComponent<PlayerMovement> ()) {
			bool reflect = Managers.player ().HitPlayer ();
			if (reflect)
				Destroy (gameObject);
		}
	}
}