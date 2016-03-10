using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour, IManager {
	
	#region IManager implementation
	public void initialization ()
	{
		LoadGameState ();
	}
	#endregion

	[SerializeField] private string _filename;

	const string INVERTORY = "invertory";
	const string CURRENT_LEVEL = "currentLevel";

	public void SaveGameState() {
		Dictionary<object, object> gamestate = new Dictionary<object, object> ();
		gamestate.Add (INVERTORY, Managers.invertory ().GetItems ());
		gamestate.Add (CURRENT_LEVEL, Managers.level().GetLevel());

		FileStream stream = File.Create (_filename);
		BinaryFormatter formatter = new BinaryFormatter ();
		formatter.Serialize (stream, gamestate);
		stream.Close ();
	}

	public void LoadGameState() {
		if (!File.Exists (_filename)) {
			Debug.Log ("No saved game");
			Managers.level ().SetLevel (1);
			return;
		}

		Dictionary<object, object> gamestate;

		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream stream = File.Open (_filename, FileMode.Open);
		gamestate = formatter.Deserialize (stream) as Dictionary<object, object>;
		stream.Close ();

		Managers.invertory().SetItems ((Dictionary<CollectableTrigger.CollectableType, float>)gamestate [INVERTORY]);
		Managers.level().SetLevel((int)gamestate[CURRENT_LEVEL]);
	}
}