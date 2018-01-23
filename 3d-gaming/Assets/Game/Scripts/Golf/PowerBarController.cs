using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerBarController : MonoBehaviour {
    // ForceBar Slider reference
    private Slider ForceSlider;
    public float currentPower = 0.0f;

    // Use this for initialization
    void Awake () {
        ForceSlider = GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        ForceSlider.value = currentPower;
    }

    public void changePowerValue(float power)
    {
        currentPower = power;
    }
}
