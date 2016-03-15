using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	
	public float dampTime = 0.5f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	private Camera _camera;

	private bool moving = false;
	private Vector3 destination = Vector3.zero;

	void Start ()
	{
		_camera = GetComponent<Camera> ();

		Managers.player ().InitCamera (gameObject);
	}

	void LateUpdate ()
	{
		if (target) {
			// goes to target or to destination vector if (moving)
			Vector3 targetPosition = ( moving && !destination.Equals(Vector3.zero) ) ?
				destination : new Vector3 (target.position.x, target.position.y + 0.5f, target.position.z);
			Vector3 point = _camera.WorldToViewportPoint (targetPosition);
			Vector3 delta = targetPosition - _camera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
			Vector3 cameraDestination = transform.position + delta;

			transform.position = Vector3.SmoothDamp (transform.position, cameraDestination, ref velocity, dampTime);

		}

	}

	public void Rotate180 ()
	{
		if (gameObject.transform.rotation.Equals (Quaternion.Euler(Vector3.zero)))
			RotateForward180 ();
		else
			RotateBackwards180 ();
	}

	public void RotateForward180() {
		iTween.Stop (gameObject);
		iTween.RotateTo (gameObject, new Vector3 (0f, 0f, 180f), 2.0f);
	}

	public void RotateBackwards180() {
		iTween.Stop (gameObject);
		iTween.RotateTo (gameObject, Vector3.zero, 2.0f);
	}

	public void GoToPosition (Vector3 positionToShow)
	{
		moving = true;
		destination = positionToShow;
	}

	public void GoBackFromPosition() {
		moving = false;
		destination = Vector3.zero;
	}
}