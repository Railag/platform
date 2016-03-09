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
		StartCoroutine (ReloadLevel());
	}

	IEnumerator ReloadLevel() {
		Managers.player ().HidePlayer (1f);
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void NextLevel ()
	{
		// TODO
		RestartLevel();
	}
}