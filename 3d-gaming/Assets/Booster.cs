using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float Speed = 10;
    public float BoostUpIntensity = 10;

    public bool isSpeed = false;
    public bool isUp = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (isSpeed == true)
            {
                Vector3 force = rb.velocity.normalized * Speed;
                rb.AddForce(force, ForceMode.VelocityChange);
            }
            if (isUp == true)
            {
                rb.AddForce(Vector3.up * BoostUpIntensity, ForceMode.Impulse);
            }
        }
    }
}
