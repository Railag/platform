using UnityEngine;
using System.Collections;

public class SawTrigger : Trigger
{
	
	//
	//	private bool transformCached = false;
	//
	//	private Transform cachedTransform = null;
	//
	//	public new Transform transform {
	//		get {
	//			if (!transformCached) {
	//				cachedTransform = base.transform;
	//			}
	//			return cachedTransform;
	//		}
	//		protected set {
	//			cachedTransform = value;
	//		}
	//	}
	[SerializeField]
	private float speed = -90f;

	private Rigidbody2D cachedRigidBody;
	private float currentAngle = 0;

	void Awake ()
	{
		cachedRigidBody = GetComponent<Rigidbody2D> ();
	}


	override
	public void PlayerCollide ()
	{
		Managers.player ().HitPlayer ();
	}

	void Update ()
	{
		currentAngle += speed * Time.deltaTime;
		currentAngle %= 360;
		cachedRigidBody.MoveRotation (currentAngle);
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.GetComponent<PlayerMovement> () != null) {
			PlayerCollide ();
		}
	}
}
