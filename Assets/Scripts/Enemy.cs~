using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	[SerializeField]
	float speed = 3f;

	[SerializeField]
	bool randomDirectionChange = true;

	protected GameObject lightningInstance;

	protected Rigidbody2D rigidBody;

	protected float direction = 1f;

	protected bool randomDirectionLock = false;

	private int stoppedCount = 0;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		// count blocked time without velocity
		if (Mathf.Abs (rigidBody.velocity.x) < 1f) {
			stoppedCount++;
		}

		// change direction if no movement (blocked)
		if (stoppedCount >= 4) {
			ChangeDirection ();
			stoppedCount = 0;
		}

		if (randomDirectionChange && !randomDirectionLock) {
			float directionChangeRandom = Random.value;
		//	Debug.Log (directionChangeRandom);
			if (directionChangeRandom > 0.99f) {
				ChangeDirection ();
				randomDirectionLock = true;
				StartCoroutine (LockRandomDirectionChange());
			}
		}

		rigidBody.velocity = new Vector2 (speed * direction, rigidBody.velocity.y);
		transform.localScale = new Vector3 (-direction, 1, 1);
	}

	IEnumerator LockRandomDirectionChange ()
	{
		yield return new WaitForSeconds (7f);

		randomDirectionLock = false;
	}

	public void ChangeDirection() {
		direction *= -1f;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.GetComponent<PlayerMovement> ()) {
			bool reflect = Managers.player ().HitPlayer ();
			if (reflect && lightningInstance == null) {
				float collisionAngle = Vector3.Angle (collision.transform.position, collision.rigidbody.velocity);
				Quaternion rotation = Quaternion.Euler (collisionAngle, -90f, 90f);
				Vector3 position = (collision.transform.position + transform.position) * 0.5f;
				lightningInstance = Instantiate (Managers.enemy().GetSparkPrefab(), position, rotation) as GameObject;
				StartCoroutine (Death (0.3f));
			}
		}
	}

	IEnumerator Death (float seconds)
	{

		iTween.FadeTo (gameObject, 0f, seconds);

		yield return new WaitForSeconds (seconds);

		Destroy (gameObject);
		Destroy (lightningInstance);
	}

}