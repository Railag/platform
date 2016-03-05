using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IManager {

	[SerializeField] GameObject player;

	private static int reverseTime = 10; 

	public float defaultSpeed = 3.0f;

	private Vector3[] savedPositions = new Vector3[reverseTime];
	private int timeIndex = 0;

	private float speed;
	
	#region IManager implementation

	public void initialization ()
	{
		SetSpeed (3.0f);

		InvokeRepeating ("savePosition", 0, 1.0f);
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

	private void savePosition() {
		savedPositions[timeIndex] = player.transform.position;
		Debug.Log ("Vector: " + savedPositions [timeIndex] + ", index: " + timeIndex);
		if (timeIndex != savedPositions.Length - 1)
			timeIndex++;
		else
			timeIndex = 0;
	}

	public void BackInTime() {
		// next index
		int index = timeIndex == savedPositions.Length - 1 ? 0 : timeIndex + 1;

		// less than 10 game seconds passed.
		if (savedPositions[index] == Vector3.zero) {
			index = 0;
		}

		player.transform.position = savedPositions[index];
	}

}