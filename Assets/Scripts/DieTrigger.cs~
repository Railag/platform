using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DieTrigger : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.GetComponent<PlayerMovement>() != null) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}
