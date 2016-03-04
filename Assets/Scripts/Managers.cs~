using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Managers : MonoBehaviour {

	[SerializeField] UIManager uiManager;
	[SerializeField] InvertoryManager invertoryManager;

	private List<IManager> managers;

	void Start () {
		managers = new List<IManager> ();

		managers.Add (uiManager);
		managers.Add (invertoryManager);

		foreach(IManager manager in managers) {
			manager.initialization ();
		}
			
	}

	public UIManager ui() {
		return uiManager;
	}

	public InvertoryManager invertory() {
		return invertoryManager;
	}
}
