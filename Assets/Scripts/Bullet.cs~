using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	[SerializeField] float speed = 10f;

	private float direction = 1f;
	private Rigidbody2D rigidBody;

	void Start ()
	{
		Invoke ("DestroyBullet", 5f);
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		rigidBody.velocity = new Vector2 (speed * direction, rigidBody.velocity.y);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.GetComponent<PlayerMovement> () != null) {
			Managers.player ().HitPlayer ();
			Destroy (gameObject);
			return;
		}
			
		Destroy (gameObject);
	}

	void DestroyBullet ()
	{
		Destroy (gameObject);
	}

	public void SetDirection (float direction)
	{
		this.direction = direction;
	}

}