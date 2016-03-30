﻿using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour, IManager
{
	[SerializeField] private GameObject sparkPrefab;
	[SerializeField] private GameObject bulletPrefab;

	#region IManager implementation

	public void initialization ()
	{
		
	}

	#endregion

	public GameObject GetSparkPrefab ()
	{
		return sparkPrefab;
	}

	public GameObject GetBulletPrefab()
	{
		return bulletPrefab;
	}
}