using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Managers : MonoBehaviour
{

	private static UIManager uiManager;
	private static InvertoryManager invertoryManager;
	private static PlayerManager playerManager;
	private static LevelManager levelManager;
	private static DataManager dataManager;
	private static EnemyManager enemyManager;

	private List<IManager> managers;

	public void Awake ()
	{
		DontDestroyOnLoad (this);

		Physics2D.IgnoreLayerCollision (8, 8);
	}

	void LateUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			data ().ResetGameState ();
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			level ().NextLevel ();
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			level ().PrevLevel ();
		}
	}

	void Start ()
	{
		managers = new List<IManager> ();

		uiManager = GetComponent<UIManager> ();
		invertoryManager = GetComponent<InvertoryManager> ();
		playerManager = GetComponent<PlayerManager> ();
		levelManager = GetComponent<LevelManager> ();
		dataManager = GetComponent<DataManager> ();
		enemyManager = GetComponent<EnemyManager> ();

		managers.Add (uiManager);
		managers.Add (invertoryManager);
		managers.Add (playerManager);
		managers.Add (levelManager);
		managers.Add (dataManager);
		managers.Add (enemyManager);

		foreach (IManager manager in managers) {
			manager.initialization ();
		}
			
	}

	public static UIManager ui ()
	{
		return uiManager;
	}

	public static InvertoryManager invertory ()
	{
		return invertoryManager;
	}

	public static PlayerManager player ()
	{
		return playerManager;
	}

	public static LevelManager level ()
	{
		return levelManager;
	}

	public static DataManager data ()
	{
		return dataManager;
	}

	public static EnemyManager enemy ()
	{
		return enemyManager;
	}
}
