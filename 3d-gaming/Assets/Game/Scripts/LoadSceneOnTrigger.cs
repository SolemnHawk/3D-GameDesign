using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour {
	// On Awake:
	//  - Require a collider for the attached gameObject.
	//  - Make the collider a trigger
	public int levelId;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			SceneManager.LoadScene (levelId);
		}
	}
}
