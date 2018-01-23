using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGameObject : MonoBehaviour {

	[Header("Rotation")]
	public float x;
	public float y;
	public float z;

	private Transform objectTransform;

	// Use this for initialization
	void Start () {
		objectTransform = this.gameObject.GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		objectTransform.eulerAngles = new Vector3 (
			objectTransform.eulerAngles.x + x,
			objectTransform.eulerAngles.y + y,
			objectTransform.eulerAngles.z + z
		);
	}
}
