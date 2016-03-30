using UnityEngine;
using System.Collections;

public class ShootingEnemy : Enemy
{
	private GameObject bulletInstance;
	private Animator animator;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		animator.GetBehaviour<ShootingBehaviour> ().SetEnemy (this);
	}
		
	public void Shoot ()
	{
		Vector3 position = new Vector3 (transform.position.x + (0.5f * direction), transform.position.y - 0.1f, transform.position.z);
		bulletInstance = Instantiate (Managers.enemy ().GetBulletPrefab (), position, Quaternion.Euler(Vector3.zero)) as GameObject;
		bulletInstance.GetComponent<Bullet> ().SetDirection (direction);
		bulletInstance.transform.localScale = new Vector3 (direction * bulletInstance.transform.localScale.x, bulletInstance.transform.localScale.y, bulletInstance.transform.localScale.z);
	}
}