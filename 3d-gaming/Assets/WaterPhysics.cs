using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysics : MonoBehaviour
{
    // Water Physics
    public float Level = 0f;
    public float Bounce = 0.05f;
    public float Height = 1f;
    public float Force;
    public Vector3 buoyancyOffset;
    public Vector3 Point;
    public Vector3 UpLift;

    private Rigidbody rb;
    public bool inWater = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Level = rb.transform.position.y;
    }
    void Update()
    {
        if (inWater == true)
        {
            Force = 1 - ((Point.y - Level) / Height);
            Point = transform.position + transform.TransformDirection(buoyancyOffset);
            if (Force > 50)
            {
                Force = Force / 2;
            }
            else if (Force > 0)
            {
                UpLift = -(Physics.gravity * (Force - rb.velocity.y * Bounce));
                rb.AddForceAtPosition(UpLift, Point);
            }
        }
    }
    // Collision Checking...
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if (collision.gameObject.CompareTag("water"))
        {
            print("Object in the water ");
            Level = contact.point.y;
            inWater = true;
        }
        else
            inWater = false;
    }
}

