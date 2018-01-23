using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTally : MonoBehaviour
{

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HolesCompleted>().value += 1;
        }
    }
}
