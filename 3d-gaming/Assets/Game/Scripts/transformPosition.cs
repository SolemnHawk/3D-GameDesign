using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformPosition : MonoBehaviour {


	public GameObject objectectA;
	public GameObject objectectB;
	public float slowness;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(moveToX(objectectA.transform, objectectB.transform.position, slowness));
	}


	bool isMoving = false;

	IEnumerator moveToX(Transform fromPosition, Vector3 toPosition, float duration)
	{
		//Make sure there is only one instance of this function running
		if (isMoving)
		{
			yield break; ///exit if this is still running
		}
		isMoving = true;

		float counter = 0;

		//Get the current position of the object to be moved
		Vector3 startPos = fromPosition.position;

		while (counter < duration)
		{
			counter += Time.deltaTime;
			fromPosition.position = Vector3.Lerp(startPos, toPosition, counter / duration);
			yield return null;
		}

		isMoving = false;
	}

}
