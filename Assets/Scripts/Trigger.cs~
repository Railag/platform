using UnityEngine;
using System.Collections;

public abstract class Trigger : MonoBehaviour {

	public abstract void PlayerCollide();

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.GetComponent<PlayerMovement>() != null) {
			PlayerCollide ();
		}
	}

}
