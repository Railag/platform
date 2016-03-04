using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	[SerializeField] CollectableType type;


	enum CollectableType {
		None,
		Lightning,
		Health,
		FlashSpeed,
		ReverseTime,
		RightSpeed
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.GetComponent<PlayerMovement>() != null) {
			CollectItem ();
			Destroy (gameObject);
		}
	}

	private void CollectItem() {
		// TODO
	}
		
}
