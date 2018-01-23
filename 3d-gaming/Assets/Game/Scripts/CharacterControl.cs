using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	private GameObject agent;

	// Use this for initialization
	void Start()
	{
		// Create a reference to this game object.
		agent = this.gameObject;
	}

	// Update is called once per frame
	void Update () {
		// Agent Controls
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			agent.transform.Translate (0, 0, +1);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			agent.transform.Translate (Vector3.right);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			agent.transform.Translate (0, 0, -1);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			agent.transform.Translate (Vector3.left);
		}
	}
}
