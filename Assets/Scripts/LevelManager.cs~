using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IManager
{

	const int MAX_LEVEL = 3;

	private int _currentLevel;

	private bool isLoading = false;

	#region IManager implementation

	public void initialization ()
	{
		
	}

	#endregion

	public void RestartLevel ()
	{
		if (isLoading)
			return;

		isLoading = true;

		StartCoroutine (ReloadLevel ());
	}

	IEnumerator ReloadLevel ()
	{
		if (Managers.player ().hasPlayer ())
			Managers.player ().HidePlayer (1f);
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("level " + _currentLevel);
		Managers.data ().LoadGameState ();
		isLoading = false;
	}

	public void NextLevel ()
	{
		if (isLoading)
			return;

		isLoading = true;

		StartCoroutine (LoadNextLevel ());
	}

	IEnumerator LoadNextLevel ()
	{
		yield return new WaitForSeconds (1);

		_currentLevel++;

		Managers.data ().SaveGameState ();

		if (_currentLevel > MAX_LEVEL)
			GameFinished ();
		else
			SceneManager.LoadScene ("level " + _currentLevel);

		isLoading = false;
	}

	public void SetLevel (int currentLevel)
	{
		_currentLevel = currentLevel;
		RestartLevel ();
	}

	public float GetLevel ()
	{
		return _currentLevel;
	}

	void GameFinished ()
	{
		// TODO
		Debug.Log("Game is finished");
	}
}