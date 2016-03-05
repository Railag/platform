using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IManager {

	public float defaultSpeed = 3.0f;

	private float speed;
	
	#region IManager implementation

	public void initialization ()
	{
		SetSpeed (3.0f);
	}

	#endregion

	public void SetSpeed(float speed) {
		this.speed = speed;

		if (speed != defaultSpeed) {
			StartCoroutine (ResetSpeed(7.0f));
		}
	}

	IEnumerator ResetSpeed(float delay) {
		yield return new WaitForSeconds (delay);

		speed = defaultSpeed;
	}

	public float Speed() {
		return speed;
	}

}
