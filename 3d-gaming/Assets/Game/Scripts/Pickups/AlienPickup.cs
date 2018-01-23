using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPickup : MonoBehaviour {

	public GameObject hintpath;
	public GameObject hinttext;


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			hintpath.SetActive (true);
			hinttext.SetActive (false);
		}
}
}