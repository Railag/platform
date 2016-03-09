using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour
{

	[SerializeField] private GameObject _lightning;
	[SerializeField] private GameObject _health;


	void Start ()
	{
		_lightning.SetActive (false);
		_health.SetActive (false);
	}

	public void LightningEffect ()
	{
		StartCoroutine (Lightning ());
	}

	IEnumerator Lightning ()
	{
		_lightning.SetActive (true);

		yield return new WaitForSeconds (5);

		_lightning.SetActive (false);
	}

	public void HealthEffect ()
	{
		StartCoroutine (Health ());
	}

	IEnumerator Health ()
	{
		_health.SetActive (true);

		yield return new WaitForSeconds (2);

		_health.SetActive (false);
	}

}