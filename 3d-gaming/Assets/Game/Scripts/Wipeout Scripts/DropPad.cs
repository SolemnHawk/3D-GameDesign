using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPad : MonoBehaviour {
	public Rigidbody rb;
	bool triggered=false;   //triggers if player steps on
	// Use this for initialization
	void Start () {
		rb= GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered==true)
		StartCoroutine (dropFloor ()); //starts a coroutine to create a time delay
	}

	void OnTriggerEnter(Collider other){    //on player touch, set trigger to true
		if (other.tag == "Player") {
			triggered = true;
		}
	}
	IEnumerator dropFloor()
	{
		yield return new WaitForSeconds (2);
		rb.useGravity = true;   //drops platform after 2 seconds
		rb.isKinematic=false;

	}
}
