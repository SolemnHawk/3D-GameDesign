using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesCompleted : MonoBehaviour {
    public int value = 0;
    public GameObject Mono;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (value == 3)
        {
            Mono.SetActive(true);
        }
	}
}
