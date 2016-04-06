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

	private Vector2 startTouch = -Vector2.one;

	private float height;

	public float move;
	private bool vertical;

	enum TouchState
	{
		NONE,
		LEFT,
		RIGHT
	}

	private TouchState state;

	private int activeTouches = 0;

	void Start ()
	{
		Managers.player ().InitPlayer (gameObject);

		rigidBody = GetComponent<Rigidbody2D> ();

		Vector3 size = GetComponent<Renderer> ().bounds.size;
		Vector3 scale = transform.localScale;
		height = size.y * scale.y;

		Managers.invertory ().AddItem (CollectableTrigger.CollectableType.RightSpeed);
		Managers.invertory ().AddItem (CollectableTrigger.CollectableType.RightSpeed);
	
		Managers.invertory ().AddItem (CollectableTrigger.CollectableType.Lightning);
		Managers.invertory ().AddItem (CollectableTrigger.CollectableType.ReverseTime);
		Managers.invertory ().AddItem (CollectableTrigger.CollectableType.ReverseTime);
	}

	void Update() {
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		move = Input.GetAxis ("Horizontal");
		#else
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				//Touch touch = Input.GetTouch (0);

				if (touch.phase == TouchPhase.Began) {
					activeTouches++;

					Vector2 viewportPosition = Camera.main.WorldToViewportPoint (touch.position);
					Vector2 center = Camera.main.WorldToViewportPoint (Camera.main.pixelRect.center);
					float distanceFromCenter = Vector2.Distance (center, viewportPosition);

					if (distanceFromCenter < 20f) { // handling for center
						vertical = true; // the same direction left
						Debug.Log ("Touches: " + Input.touchCount);
						if (Input.touchCount == 1) // pressed jump and no other moves
							state = TouchState.NONE;
					} else { // handling for left/right
						if (viewportPosition.x > center.x) {
							state = TouchState.RIGHT;
						} else {
							state = TouchState.LEFT;
						}
					}

					//startTouch = touch.position;
				} else if (touch.phase == TouchPhase.Ended) {
					activeTouches--;
					if (activeTouches == 0)
						state = TouchState.NONE;
					//				Vector2 endTouch = touch.position;
					//				float xDiff = endTouch.x - startTouch.x;
					//				float yDiff = endTouch.y - startTouch.y;
					//				startTouch.x = -1;
					//
					//				if (xDiff < -10f)
					//					move = -1f;
					//				else
					//					move = xDiff;
					//				
					//				if (move > 1f)
					//					move = 1f;
					//				
					//				if (yDiff > 10f) {
					//					vertical = true;
					//				}
					//				if (move > 0f)
					//					Debug.Log("Start touch: " + xDiff + "  | End touch: " + endTouch + "  | Move: " + move);
				} else if (touch.phase == TouchPhase.Stationary) { // user pressed jump and then tapped left/right, only pressed jump left
					if (Input.touchCount == 1) {
						Vector2 viewportPosition = Camera.main.WorldToViewportPoint (touch.position);
						Vector2 center = Camera.main.WorldToViewportPoint (Camera.main.pixelRect.center);
						float distanceFromCenter = Vector2.Distance (center, viewportPosition);

						if (distanceFromCenter < 20f) {
							state = TouchState.NONE;
						}
					}
				}
			}
		} else {
			state = TouchState.NONE;
		}

		switch (state) {
		case TouchState.NONE:
			move = 0f;
			break;
		case TouchState.LEFT:
			move = -1f;
			break;
		case TouchState.RIGHT:
			move = 1f;
			break;
		}

		#endif

	}

	void FixedUpdate ()
	{
		rigidBody.velocity = new Vector2 (move * Managers.player ().Speed (), rigidBody.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		Vector2 position = new Vector2 (transform.position.x, transform.position.y - height / 2 - 1f);

		RaycastHit2D grounded = Physics2D.CircleCast (position, groundRadius, Vector2.down, groundDistance);

		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		vertical = Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow);
		#endif

		if (grounded && vertical) {
			rigidBody.AddForce (new Vector2 (0f, jumpForce));
			//	Debug.Log ("X: " + position.x + " Y: " + position.y + " distance: " + grounded.distance + " name: " + grounded.collider.name + " height: " + height);
		}

		vertical = false;
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
