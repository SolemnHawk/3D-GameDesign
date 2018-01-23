using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putter : MonoBehaviour {
    bool reverse = false;
    public float forceBar;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {

        GetComponent<ConstantForce>().enabled = false;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
            if (Input.GetMouseButton(0))
            {
                if (reverse == false)
                {
                    if (forceBar != 2500)
                    {
                        forceBar += 100;
                    }
                    else
                    {
                        reverse = true;
                        forceBar -= 100;
                    }
                }
                else
                {
                    if (forceBar != 0)
                    {
                        forceBar -= 100;
                    }
                    else
                    {
                        reverse = false;
                        forceBar += 100;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Pressed left click.");
                rb.AddRelativeForce(Vector3.forward *forceBar);
                GetComponent<ConstantForce>().enabled = true;
                reverse = false;
                Wait(5);
            }
        }

    private void Wait(int sec)
    {
        for(int i = 0; i < sec ;i++)
        {
            //DO NOTHING :D
        }
        GetComponent<ConstantForce>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
