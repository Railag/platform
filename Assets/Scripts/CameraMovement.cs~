using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	[SerializeField] public Camera camera;
	
	public float dampTime = 0.5f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	void Update () 
	{
		if (target)
		{
			Vector3 targetPosition = new Vector3 (target.position.x, target.position.y + 0.5f, target.position.z);
			Vector3 point = camera.WorldToViewportPoint(targetPosition);
			Vector3 delta = targetPosition - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;


			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

	}
}
