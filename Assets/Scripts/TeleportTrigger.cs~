using UnityEngine;
using System.Collections;

public class TeleportTrigger : Trigger {
	[SerializeField] private GameObject secondTeleport;

	private static bool teleporting = false;

	override
	public void PlayerCollide() {
		if (!teleporting) {
			teleporting = true;
			Managers.player ().TeleportTo (secondTeleport.transform.position);
			StartCoroutine (UnlockTeleport ());
		}
	}

	IEnumerator UnlockTeleport ()
	{
		yield return new WaitForSeconds (2.5f);

		teleporting = false;
	}
}