using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public int AbilityNumber = 0;
    /// <Abilities reference sheet>
    /// 0 = Nothing
    /// 1 = Boost
    /// 2 = Jump with Anvil
    /// 3 = Hook
    /// </summary>
    // Use this for initialization

    private PlayerController Player;
    private PickupFloat Pickup;
    private Rigidbody rb;
    public bool slotEmpty = false;
    public bool AbilityActive = false;
    public bool PrimaryActive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GetComponent<PlayerController>();
        Pickup = GameObject.Find("ablity").GetComponent<PickupFloat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AbilityNumber != 0)
        {
            if (AbilityActive == true )
            {
                if (Input.GetKeyDown("Space"))
                {
                    if(AbilityNumber == 1)
                    {
                        // Display something to show boost
                        Boost();
                    }
                    else if (AbilityNumber == 2)
                    {
                        if (PrimaryActive == true && Player.isGrounded == true)
                        {
                            Jump();
                            PrimaryActive = false;
                        }
                        else
                        {
                            Anvil();
                            PrimaryActive = true;
                        }
                    }
                    else if (AbilityNumber == 3)
                    {
                        Hook();
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if the game object enters in the trigger area of another object with this tag do this...
        if (other.gameObject.CompareTag("ability"))
        {
            if (slotEmpty == true)
            {
                Pickup = other.gameObject.GetComponent<PickupFloat>();
                AbilityNumber = Pickup.AbilityNumber;
                slotEmpty = true;
                other.gameObject.SetActive(false);
            }
        }
    }

    private void Boost()
    {
        Player.forceMax = 1600.0f;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
    }

    private void Anvil()
    {
        rb.velocity = new Vector3(0, 10, 0);
    }

    private void Hook()
    {

    }

    private void Reset()
    {
        Player.forceMax = 1100.0f;
    }
}
