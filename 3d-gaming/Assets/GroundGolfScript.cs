using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGolfScript : MonoBehaviour {
    private Transform m_currentPlatform;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            m_currentPlatform = collision.gameObject.transform;
            transform.SetParent(m_currentPlatform);
        }
    }
}
