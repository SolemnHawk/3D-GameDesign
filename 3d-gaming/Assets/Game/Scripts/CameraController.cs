using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Constraint on view angle
    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    // What the camera will be looking at
    public Transform lookAt;
    // Transform of the Camera itself
    public Transform camTransform;

    private Camera cam;

    private float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 45.0f;

    // Mouse Sensivit
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    // At the start of the game..
    void Start()
    {
        // Reference for lookAt object should already defined in Unity Inspector (Under Script)
        // On top of camera object
        camTransform = transform;
        // Get first enabled main camera
        cam = Camera.main;
    }

    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");

            // Set the Clamp on the angle restricting rotation of camera
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
        // Scroll Wheel to increase elevation of camera
        /*
        if (Input.GetAxis("Mouse Scroll Wheel") > 0)
        {
            GetComponent<Camera>().fieldOfView -= 1;
        }
        if (Input.GetAxis("Mouse Scroll Wheel") < 0)
        {
            GetComponent<Camera>().fieldOfView += 1;
        }
        */
    }

    // After Movement happens we update the most current position, that's why LateUpdate is needed
    // Or Simply, this runs after the standard 'Update()' loop runs, and just before each frame is rendered..
    void LateUpdate()
    {
        // Direction of the Camera
        Vector3 dir = new Vector3(0, 0, -distance);

        // Constructing new Rotation
        Quaternion rotation = Quaternion.Euler(currentY, currentX,0);

        // Move the transform of the Camera
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }

}
