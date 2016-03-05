using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IManager {
	
	#region IManager implementation

	public void initialization ()
	{
		
	}

	#endregion

	public void RestartLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}