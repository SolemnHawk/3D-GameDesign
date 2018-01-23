using System.Collections;
using System.Collections.Generic;
using UnityEngine.Collections;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class PlayerFormUserControl: MonoBehaviour {

	// Reference game objects in the scene.
	private GameObject ball;
	private GameObject bob;

	// Reference camera and its attached script.
	private GameObject camObject;
	private FreeLookCam camScript;

	[Header("Player Form Options")]
	public bool canTransform = true;
	public int currentForm = 1;

	private int ballForm = 1;
	private int bobForm = 2;

	private Vector3 location;

	private void Awake() {
		// Get game objects
		ball = transform.Find ("RollerBall").gameObject;
		bob = transform.Find ("ThirdPersonController").gameObject;
		// Get camera and its attached script
		camObject = transform.Find ("Camera/FreeLookCameraRig").gameObject;
		camScript = camObject.GetComponent<FreeLookCam> ();
		location = new Vector3 (0, 0, 0);
		getInitialForm (currentForm);
	}

	// Update is called once per frame
	private void Update () {
		if (canTransform) {
			// Allow player to change forms using numeric input 1 and 2.
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				currentForm = ballForm;
				// Change game objects.
				activateBobForm(false);
				activateBallForm(true);
				// Have camera focus on the game object.
				camScript.SetTarget(ball.transform);
				// Set the current transform as the transform of the game object.
				ball.transform.SetPositionAndRotation(location, new Quaternion(0,0,0,0));
				bob.transform.Rotate (new Vector3(0, camObject.transform.rotation.eulerAngles.y+180, 0));
				// Apply the current velocity to the game object.
				//ball.GetComponent<Rigidbody> ().AddForce (bob.GetComponent<Rigidbody> ().velocity, ForceMode.VelocityChange);
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				currentForm = bobForm;
				activateBallForm(false);
				activateBobForm(true);
				camScript.SetTarget(bob.transform);
				// Set the position, and rotation so the car faces in the direction of the camera.
				bob.transform.SetPositionAndRotation(location, new Quaternion(0,0,0,0));
				bob.transform.Rotate (new Vector3(0, camObject.transform.rotation.eulerAngles.y, 0));
				//bob.GetComponent<Rigidbody> ().AddForce (ball.GetComponent<Rigidbody> ().velocity, ForceMode.VelocityChange);
			}
		}
		if (currentForm == ballForm) {
			location = ball.transform.position;
		}
		else if (currentForm == bobForm) {
			location = bob.transform.position;
		}
	}

	private void getInitialForm (int form){
		if (currentForm == ballForm) {
			activateBobForm (false);
			activateBallForm (true);
			camScript.SetTarget(ball.transform);
		} else if (currentForm == bobForm) {
			activateBallForm (false);
			activateBobForm (true);
			camScript.SetTarget(bob.transform);
		}
	}

	private void activateBallForm (bool isActive) {
		ball.SetActive (isActive);
	}

	private void activateBobForm (bool isActive){
		bob.SetActive (isActive);
	}

}
