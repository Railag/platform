using UnityEngine;
using System.Collections;

public class EnemyBlock : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.GetComponent<Enemy> ()) {
			collider.GetComponent<Enemy> ().ChangeDirection ();
		}
	}
}