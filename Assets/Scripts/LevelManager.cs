using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IManager
{

	const int MAX_LEVEL = 12;

	private int _currentLevel;

	private bool isLoading = false;

	private AsyncOperation loadingOperation;

	#region IManager implementation

	public void initialization ()
	{
		
	}

	#endregion

	public void Update() {
		if (isLoading || loadingOperation != null && !loadingOperation.isDone) {
			//float progress = loadingOperation.progress; 
			Managers.ui ().DisplayLoading ();
		} else {
			Managers.ui ().StopLoading ();
		}
	}
		
	public void RestartLevel ()
	{
		if (isLoading || loadingOperation != null && !loadingOperation.isDone)
			return;

		isLoading = true;

		StartCoroutine (ReloadLevel ());
	}

	IEnumerator ReloadLevel ()
	{
		if (Managers.player ().HasPlayer ()) {
			Managers.player ().HidePlayer (1f);
			Managers.ui ().DisplayDialog ("ha ha", 1.5f);
		}
		yield return new WaitForSeconds (1);
		loadingOperation = SceneManager.LoadSceneAsync ("level " + _currentLevel);
		Managers.data ().LoadGameState ();
		isLoading = false;
	}

	public void NextLevel ()
	{
		if (isLoading || loadingOperation != null && !loadingOperation.isDone)
			return;

		isLoading = true;

		_currentLevel++;

		StartCoroutine (LoadNextLevel ());
	}

	public void PrevLevel ()
	{
		if (isLoading || loadingOperation != null && !loadingOperation.isDone)
			return;

		isLoading = true;

		_currentLevel--;

		StartCoroutine (LoadNextLevel ());
	}

	IEnumerator LoadNextLevel ()
	{
		yield return new WaitForSeconds (1);

		Managers.data ().SaveGameState ();

		if (_currentLevel > MAX_LEVEL || _currentLevel < 1)
			GameFinished ();
		else
			loadingOperation = SceneManager.LoadSceneAsync ("level " + _currentLevel);

		isLoading = false;
	}

	public void SetLevel (int currentLevel)
	{
		_currentLevel = currentLevel;
		RestartLevel ();
	}

	public int GetLevel ()
	{
		return _currentLevel;
	}

	void GameFinished ()
	{
		// TODO
		Debug.Log("Game is finished");
	}
}