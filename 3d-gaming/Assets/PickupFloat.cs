using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFloat : MonoBehaviour {

    public int AbilityNumber = 0;
    /// <Abilities reference sheet>
    /// 0 = Nothing
    /// 1 = Boost
    /// 2 = Jump with Anvil
    /// 3 = Hook
    /// </summary>
    // Use this for initialization

    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start () {
        posOffset = transform.position;
    }

    private void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }

}
