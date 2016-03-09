using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {

	[SerializeField] private GameObject _lightning;


	void Start () {
		_lightning.SetActive (false);
	}

	public void LightningEffect() {
		_lightning.SetActive (true);
	}
}