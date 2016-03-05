using UnityEngine;
using System.Collections;

public class SawTrigger : Trigger {

	private bool transformCached = false;

	private Transform cachedTransform = null;

	public new Transform transform {
		get {
			if (!transformCached) {
				cachedTransform = base.transform;
			}
			return cachedTransform;
		}
		protected set {
			cachedTransform = value;
		}
	}

	override
	public void PlayerCollide() {
		Managers.player ().HitPlayer ();
	}

	void Update() {
		transform.Rotate (0f, 0f, -3f);
	}
}
