using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterdeath : MonoBehaviour {

	private DeathCountScript deathscript;

	// Use this for initialization
	void Start () {
		deathscript=GetComponent<DeathCountScript>();
	}
	
	void OnTriggerEnter(Collider other){    //on player touch, set trigger to true
		if (other.tag == "Player") {
			deathscript.deathup ();
		}
	}

}