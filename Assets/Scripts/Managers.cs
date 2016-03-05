using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Managers : MonoBehaviour {

	private static UIManager uiManager;
	private static InvertoryManager invertoryManager;
	private static PlayerManager playerManager;

	private List<IManager> managers;

	void Start () {
		managers = new List<IManager> ();

		uiManager = GetComponent<UIManager> ();
		invertoryManager = GetComponent<InvertoryManager> ();
		playerManager = GetComponent<PlayerManager> ();

		managers.Add (uiManager);
		managers.Add (invertoryManager);
		managers.Add (playerManager);

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

	public static PlayerManager player() {
		return playerManager;
	}
}
