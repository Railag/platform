using UnityEngine;
using System.Collections;

public class GroundMovingTrigger : Trigger
{

	[SerializeField] GameObject ground;
	[SerializeField] Direction direction;
	[SerializeField] float seconds = 3.0f;
	[SerializeField] float distance = 5.0f;
	[SerializeField] Sprite activeSprite;
	private Sprite inactiveSprite;

	private bool active = false;

	private Vector3 distanceVector;

	enum Direction
	{
		left,
		right
	}

	void Start ()
	{
		distanceVector = new Vector3 (distance, 0f, 0f);
		inactiveSprite = GetComponent<SpriteRenderer> ().sprite;
	}

	override
	public void PlayerCollide ()
	{
		if (active)
			return;
		
		active = true;
		GetComponent<SpriteRenderer> ().sprite = activeSprite;

		switch (direction) {
		case Direction.left:
			iTween.MoveBy (ground, -distanceVector, seconds);
			break;
		case Direction.right:
			iTween.MoveBy (ground, distanceVector, seconds);
			break;
		}

		StartCoroutine (MoveBack ());
	}

	IEnumerator MoveBack ()
	{
		yield return new WaitForSeconds (seconds);

		switch (direction) {
		case Direction.left:
			iTween.MoveBy (ground, distanceVector, 0.5f);
			break;
		case Direction.right:
			iTween.MoveBy (ground, -distanceVector, 0.5f);
			break;
		}

		active = false;
		GetComponent<SpriteRenderer> ().sprite = inactiveSprite;
	}
}