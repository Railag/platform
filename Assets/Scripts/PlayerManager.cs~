using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IManager
{

	private GameObject _player;
	private GameObject _camera;

	private static int reverseTime = 10;

	public float defaultSpeed = 3.0f;

	private Vector3[] savedPositions = new Vector3[reverseTime];
	private int timeIndex = 0;

	private float speed;

	private bool unbreakable = false;

	private bool electric = false;

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
		if (!HasPlayer())
			return;
		
		savedPositions [timeIndex] = _player.transform.position;
//		Debug.Log ("Vector: " + savedPositions [timeIndex] + ", index: " + timeIndex);
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

		SteelWithNoEffect (2);
		iTween.MoveTo (_player, savedPositions[index], 2f);
	}

	public void PushPlayerForward (float power)
	{
		StartCoroutine (PushPlayer (20, power / 20));
	}

	IEnumerator PushPlayer (int times, float power)
	{
		for (int i = 0; i < times; i++) {
			_player.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (power, 0f));
			yield return new WaitForFixedUpdate ();
		}
	}

	public bool HitPlayer ()
	{
		if (!unbreakable) {
			Managers.level ().RestartLevel ();
		}

		return electric;
	}

	public void Steel(int seconds) {
		unbreakable = true;

		HealthEffect ();

		StartCoroutine (Breakable (seconds));
	}

	public void SteelWithNoEffect(int seconds) {
		unbreakable = true;

		StartCoroutine (Breakable (seconds));
	}

	IEnumerator Breakable (int seconds)
	{
		yield return new WaitForSeconds (seconds);

		unbreakable = false;
	}

	public void Lightning(int seconds) {
		electric = true;

		LightningEffect ();

		StartCoroutine (Deelectric (seconds));
	}

	IEnumerator Deelectric(int seconds) {
		yield return new WaitForSeconds (seconds);

		electric = false;
	}

	public void HidePlayer(float seconds) {
		iTween.FadeTo (_player, 0f, seconds);
	}

	public void LightningEffect() {
		_player.GetComponent<PlayerAttributes> ().LightningEffect ();
	}

	public void HealthEffect() {
		_player.GetComponent<PlayerAttributes> ().HealthEffect ();
	}

	public void InitPlayer (GameObject player)
	{
		this._player = player;
	}

	public bool HasPlayer ()
	{
		return _player != null;
	}

	public void InitCamera(GameObject camera) {
		this._camera = camera;
	}

	public bool HasCamera() {
		return this._camera != null;
	}

	public void RotateCamera180() {
		if (HasCamera ())
			_camera.GetComponent<CameraMovement> ().Rotate180 ();
	}

	public void IntroCamera(Vector3 positionToShow) {
		Vector3 oldPosition = _camera.transform.position;
		_camera.GetComponent<CameraMovement> ().GoToPosition (positionToShow);
		StartCoroutine (PauseMovement (oldPosition));
	}

	IEnumerator PauseMovement(Vector3 oldPosition) {
		//Backup and clear velocities
		Rigidbody2D rigidBody = _player.GetComponent<Rigidbody2D>();
		Vector2 linearBackup = rigidBody.velocity;
		float angularBackup = rigidBody.angularVelocity;
		rigidBody.velocity = Vector2.zero;
		rigidBody.angularVelocity = 0f;

		//Finally freeze the body in place so forces like gravity or movement won't affect it
		rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

		yield return new WaitForSeconds (1f);

		_camera.GetComponent<CameraMovement> ().GoBackFromPosition ();

		yield return new WaitForSeconds(1f);
		//And unfreeze before restoring velocities
		rigidBody.constraints = RigidbodyConstraints2D.None;
		//restore the velocities
		rigidBody.velocity = linearBackup;
		rigidBody.angularVelocity = angularBackup;

	}

	public void TeleportTo (Vector3 position)
	{
		SteelWithNoEffect (2);
		iTween.MoveTo (_player, position, 2f);
	}
}