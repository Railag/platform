using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Managers : MonoBehaviour {

	private static UIManager uiManager;
	private static InvertoryManager invertoryManager;

	private List<IManager> managers;

	void Start () {
		managers = new List<IManager> ();

		uiManager = GetComponent<UIManager> ();
		invertoryManager = GetComponent<InvertoryManager> ();

		managers.Add (uiManager);
		managers.Add (invertoryManager);

		foreach(IManager manager in managers) {
			manager.initialization ();
		}
			
	}

	public static UIManager ui() {
		return uiManager;
	}

	public static InvertoryManager invertory() {
		return invertoryManager;
	}
}
