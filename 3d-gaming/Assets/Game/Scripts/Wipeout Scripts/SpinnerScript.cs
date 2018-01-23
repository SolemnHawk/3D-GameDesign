using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour {

	// Use this for initialization
	void Update () {
		if (this.gameObject.CompareTag ("Spin Clockwise")) {
			transform.Rotate (new Vector3 (0, -30, 0) * Time.deltaTime);
		} else
			transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);
	}

}
