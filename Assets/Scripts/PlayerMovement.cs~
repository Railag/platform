using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

	private Rigidbody2D rigidBody;

	public float jumpForce = 300f;
	bool facingRight = true;
	public float groundRadius = 0.2f;
	public float groundDistance = 0.5f;

	private float height;

	public float move;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody2D> ();

		Vector3 size = GetComponent<Renderer> ().bounds.size;
		Vector3 scale = transform.localScale;
		height = size.y * scale.y;

		Managers.invertory ().AddItem (CollectableTrigger.CollectableType.RightSpeed);
		Managers.invertory ().AddItem (CollectableTrigger.CollectableType.Lightning);
	}

	void FixedUpdate ()
	{
		Vector2 position = new Vector2 (transform.position.x, transform.position.y - height / 2 - 1f);

		RaycastHit2D grounded = Physics2D.CircleCast (position, groundRadius, Vector2.down, groundDistance);

		if (grounded && (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))) {
			rigidBody.AddForce (new Vector2 (0f, jumpForce));
			//	Debug.Log ("X: " + position.x + " Y: " + position.y + " distance: " + grounded.distance + " name: " + grounded.collider.name + " height: " + height);
		}
	}

	void Update ()
	{
		move = Input.GetAxis ("Horizontal");


		rigidBody.velocity = new Vector2 (move * Managers.player ().Speed (), rigidBody.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		checkPressedKey ();
	}

	private void checkPressedKey ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (Input.GetKey (KeyCode.R)) {
			
		}

		// invertory
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Managers.invertory ().ConsumeItem (CollectableTrigger.CollectableType.Lightning);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Managers.invertory ().ConsumeItem (CollectableTrigger.CollectableType.Health);
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			Managers.invertory ().ConsumeItem (CollectableTrigger.CollectableType.FlashSpeed);
		} else if (Input.GetKey (KeyCode.Alpha4)) {
			Managers.invertory ().ConsumeItem (CollectableTrigger.CollectableType.ReverseTime);
		} else if (Input.GetKey (KeyCode.Alpha5)) {
			Managers.invertory ().ConsumeItem (CollectableTrigger.CollectableType.RightSpeed);
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
