using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeathCountScript : MonoBehaviour {
	public Text deathcount;
	private int count;

	// Use this for initialization
	void Start () {
		count = -1;
		deathup ();
	}
	

	public void deathup(){
		count++;
		deathcount.text = "Death Count: "+count.ToString ();
	}
}
