using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour, IManager
{
	[SerializeField] private GameObject sparkPrefab;

	#region IManager implementation

	public void initialization ()
	{
		
	}

	#endregion

	public GameObject GetSparkPrefab ()
	{
		return sparkPrefab;
	}
}
