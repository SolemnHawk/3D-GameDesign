using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {


	// Variables used in setting the XYZ coordinates of the new vector3.
	[Header("Vector3 Location")]
	public int x;
	public int y;
	public int z;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			// Get the rigidBody of the gameObject.
			Rigidbody rb = other.GetComponent<Rigidbody> ();
			// Set the velocity to zero.
			rb.velocity = Vector3.zero;
			// Set the angulary velocity to zero.
			rb.angularVelocity = Vector3.zero;
			// Reset the input axes.
			Input.ResetInputAxes ();
			// Transform the position of the gameObject with tag "Player".
			other.transform.position = new Vector3 (x, y, z);

		}
	}
}