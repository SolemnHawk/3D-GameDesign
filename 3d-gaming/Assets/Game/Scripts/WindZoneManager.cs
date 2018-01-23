using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneManager : MonoBehaviour {

	// Force variables.
	[Header("Remove Force on Exit")]
	public bool remove = true;
	[Header("Apply Effect")]
	public bool player;
	public bool platforms;
	[Header("Wind Direction")]
	public float x;
	public float y;
	public float z;

	void OnTriggerEnter(Collider other) {
		// Use conditionals with tags so only certain gameobjects are affected.
		// Get the game object
		GameObject obj = other.gameObject;
		if (other.tag == "platform" && platforms == true) {
			// Add a constant force to the game objects rigidbody.
			obj.GetComponent<ConstantForce> ().force = new Vector3 (x, y, z);
		}
		if (other.tag == "player" && player == true) {
			// Add a constant force to the game objects rigidbody.
			obj.GetComponent<ConstantForce> ().force = new Vector3 (x, y, z);
		}
	}

	void OnTriggerExit(Collider other) {
		print ("Exiting: " + other.name);
		GameObject obj = other.gameObject;
		//obj.GetComponent<ConstantForce> ().force = new Vector3(-x*2, -y*2, -z*2);
		if(remove){
			obj.GetComponent<ConstantForce> ().force = new Vector3(0, 0, 0);
		}
		//Destroy (other.GetComponent<ConstantForce>());
	}
}
