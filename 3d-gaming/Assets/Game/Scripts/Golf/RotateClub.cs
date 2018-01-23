using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClub : MonoBehaviour {
    private PlayerController player;
    public Vector3 PlayerPos;
    public Vector3 mousePos;

    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
        PlayerPos = GetComponent<PlayerController>().transform.position;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            mousePos = hit.point;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Transform objectHit = hit.transform;
            mousePos = hit.point;
            //player.MouseClickLocation(mousePos);
        }
    }
}
