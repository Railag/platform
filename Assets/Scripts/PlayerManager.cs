using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IManager
{

	[SerializeField] GameObject player;

	private static int reverseTime = 10;

	public float defaultSpeed = 3.0f;

	private Vector3[] savedPositions = new Vector3[reverseTime];
	private int timeIndex = 0;

	private float speed;

	private bool unbreakable = false;

	#region IManager implementation

	public void initialization ()
	{
		SetSpeed (3.0f);

		InvokeRepeating ("savePosition", 0, 1.0f);
	}

	#endregion

	public void SetSpeed (float speed)
	{
		this.speed = speed;

		if (speed != defaultSpeed) {
			StartCoroutine (ResetSpeed (7.0f));
		}
	}

	IEnumerator ResetSpeed (float delay)
	{
		yield return new WaitForSeconds (delay);

		speed = defaultSpeed;
	}

	public float Speed ()
	{
		return speed;
	}

	private void savePosition ()
	{
		savedPositions [timeIndex] = player.transform.position;
		Debug.Log ("Vector: " + savedPositions [timeIndex] + ", index: " + timeIndex);
		if (timeIndex != savedPositions.Length - 1)
			timeIndex++;
		else
			timeIndex = 0;
	}

	public void BackInTime ()
	{
		// next index
		int index = timeIndex == savedPositions.Length - 1 ? 0 : timeIndex + 1;

		// less than 10 game seconds passed.
		if (savedPositions [index] == Vector3.zero) {
			index = 0;
		}

		player.transform.position = savedPositions [index];
	}

	public void PushPlayerForward (float power)
	{
		StartCoroutine (PushPlayer (20, power / 20));
	}

	IEnumerator PushPlayer (int times, float power)
	{
		for (int i = 0; i < times; i++) {
			player.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (power, 0f));
			yield return new WaitForFixedUpdate ();
		}
	}

	public void HitPlayer ()
	{
		if (!unbreakable)
			Managers.level ().RestartLevel ();
	}

}