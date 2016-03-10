using UnityEngine;
using System.Collections;

public class StaticObject : MonoBehaviour {

	public void Awake() {
		DontDestroyOnLoad (this);
	}
}
