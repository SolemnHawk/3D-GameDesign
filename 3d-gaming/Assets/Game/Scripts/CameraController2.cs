using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour {
	public GameObject obj;
	public float turnSpeed = 4.0f;

	private Transform target;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		target = obj.transform;
		offset = new Vector3(target.position.x, target.position.y + 8.0f, target.position.z + 7.0f);

	}
	
	// Update is called once per frame
	void Update () {
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		transform.position = target.position + offset; 
		transform.LookAt (target);
	}
		
}
