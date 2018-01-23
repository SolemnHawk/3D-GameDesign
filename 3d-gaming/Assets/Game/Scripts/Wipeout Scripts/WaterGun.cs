using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour {
	public float delay;
	public float speed;
	public Vector3 startposition;
	public bool shooting = true;
	public Rigidbody rb;
	public Vector3 resetspot;
	private DeathCountScript deathscript;

	// Use this for initialization
	void Start () {
		startposition = transform.position;
		StartCoroutine (startDelay()); //on creation sets an individual delay on each gun
		deathscript=GetComponent<DeathCountScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
			transform.Translate (0, (speed * Time.deltaTime), 0);
			
	}

	void OnTriggerEnter(Collider other){    //on player touch, set trigger to true
		if (other.tag == "Player") {
			deathscript.deathup ();
			other.transform.position = resetspot;
		}
	}

	IEnumerator startDelay()
	{
		yield return new WaitForSeconds (delay);
		StartCoroutine (shotreset ());
	}
	IEnumerator shotreset() //coroutine infinitely spawns bullets and destroys
	{
		while (shooting) {
			yield return new WaitForSeconds (delay);
			rb.MovePosition (startposition);
		}
	}
}
