using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DieTrigger : Trigger {

	override
	public void PlayerCollide() {
		Managers.level ().RestartLevel ();
	}
}
