using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuprotator : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(45,10,45)*Time.deltaTime);
	}
}
