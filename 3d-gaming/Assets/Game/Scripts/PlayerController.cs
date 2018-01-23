using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Transform camTransform;
    private Scores scorescript;
    public Vector3 hole1 = new Vector3(0, 0, 0);
    public Vector3 hole2 = new Vector3(20f, 0, 20f);

    public Vector3 MoveVector { set; get; }
    // Force Bar
    bool reverse = false;
    private float forceMin = 0.0f;
    public float forceMax = 1100.0f;
    public float forcevalue = 0.0f;
    private float forceIncrement = 25;
    private float rotatespeed = 10f;
    private float scaledforce = 0.0f;    // Used for powerbar ui normalization 
    private bool isOutOfPlay = false;

    public Vector3 MousePosition;
    private Rigidbody rb;
    public Vector3 LastPosition;
    public bool isMoving = false;
    // Reference PowerBar
    private PowerBarController PowerBar;
    private ArrowControl Line;
    private PickupFloat Pickup;
    private Abilities CurrentAbilities;
    // For Testing
    public bool allowOutOfPlay;
    public float Forcevalue = 1.0f;
    public int PositionCounter = 0;
    public int resetCount = 10;
    public int timesReset = 0;
    public bool isGrounded = false;
    public int AbilityNumber = 0;
    private bool justHitOut = false;
    private bool canResetDrag = false;
    public Vector3 CurrentPosition;
    /// <Abilities reference sheet>
    /// 0 = Nothing
    /// 1 = Boost
    /// 2 = Jump with Anvil
    /// 3 = Hook
    /// </summary>
    // Use this for initialization
    public bool slotEmpty = true;
    public bool AbilityActive = false;
    public bool PrimaryActive = true;

    void Start()
    {
        scorescript = GetComponent<Scores>();
        // Assign the component
        PowerBar = GameObject.Find("ForceBar").GetComponent<PowerBarController>();
        Line = GameObject.Find("Line").GetComponent<ArrowControl>();
        Line.gameObject.SetActive(false);
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        LastPosition = transform.position;
    }

    void Update()
    {
        //  Calculations 
        float step = rotatespeed * Time.deltaTime;
        Vector3 HitDirection = Vector3.RotateTowards(transform.forward, MousePosition, step, 0.0f);
        CurrentPosition = transform.position;
        //  Reset(s)
        HitDirection.y = 0.0f;
        //  Fetches 
        GetComponent<ConstantForce>().enabled = false;
        MousePosition = GetDirection();
        MoveVector = getMousePosition();
        MoveVector = RotateWithView();

        //  Event Listeners
        if (isOutOfPlay == true && justHitOut == true)
        {
            isOutOfPlay = false;
            rb.isKinematic = true;
        }
        else if (justHitOut == true && isOutOfPlay == false)
        {
            rb.isKinematic = false;
            justHitOut = false;
        }
        if (isOutOfPlay == true)
        {
            scorescript.swingCount();
            // Display Out of Play on Ui
            Debug.Log("Bringing Ball Back.");
            GetComponent<ConstantForce>().enabled = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Input.ResetInputAxes();
            LastPosition.y += 0.2f;
            rb.MovePosition(LastPosition);
            justHitOut = true;
        }
        if (isMoving == false )
        {
            transform.rotation = Quaternion.LookRotation(HitDirection);
        }
        if(rb.IsSleeping() == true)
        {
            isMoving = false;
            LastPosition = transform.position;
            Debug.Log("Last Position Saved.");
        }

        if (Input.GetMouseButtonDown(0) && isMoving == false)
        {
            rb.velocity = new Vector3(0, 0, 0);
            //GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            Line.transform.position = transform.position;
            if (Line.gameObject.activeSelf != true)
            {
                Line.gameObject.SetActive(true);
            }

        }
        if (Input.GetMouseButton(0) && isMoving == false && Line.gameObject.activeSelf == true)
        {
            scaledforce = forcevalue / forceMax;
            PowerBar.changePowerValue(scaledforce);
            if (reverse == false)
            {
                if (forcevalue != forceMax)
                {
                    if (forcevalue > 300 && forcevalue < 600 && forcevalue!=forceMax)
                    {
                        forcevalue += 12.5f;
                    }
                    else
                    {
                        forcevalue += forceIncrement;
                    }
                }
                else
                {
                    reverse = true;
                    forcevalue -= forceIncrement;
                }
            }
            else
            {
                if (forcevalue != 0)
                {
                    if (forcevalue > 300 && forcevalue < 600 && forcevalue != 0)
                    {
                        forcevalue -= 12.5f;
                    }
                    else
                    {
                        forcevalue -= forceIncrement;
                    }
                }
                else
                {
                    reverse = false;
                    forcevalue += forceIncrement;
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && isMoving == false && Line.gameObject.activeSelf == true )
        {
            Debug.Log("Pressed left click.");
            rb.AddRelativeForce(0, 0, forcevalue);
            isMoving = true;
            forcevalue = 0.0f;
            PowerBar.changePowerValue(forcevalue);
            GetComponent<ConstantForce>().enabled = true;
            reverse = false;
            scorescript.swingCount();
            Line.gameObject.SetActive(false);
            PositionCounter = 0;
        }
        if (Input.GetKeyDown("tab"))
        {
            scorescript.scoreBoard.SetActive(true);
        }
        if (Input.GetKeyUp("tab"))
        {
            scorescript.scoreBoard.SetActive(false);
        }

        if (scorescript.scoreBoard.activeSelf)
        {
            if (Input.GetKeyDown("return"))
            {
                scorescript.HideScores();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                Input.ResetInputAxes();
                transform.position = hole2;
            }
        }
        if (CrossPlatformInputManager.GetButton("Jump"))
        {
            Debug.Log("Space Pressed");
        }
        // Abilities
        if (Input.GetKeyDown("space") && AbilityActive == true)
        {
            Debug.Log("Space Pressed");
            if (AbilityNumber == 1)
            {
                // Display something to show boost
                Boost();
            }
            else if (AbilityNumber == 2)
            {
                if (PrimaryActive == true && isGrounded == true)
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
            else
            {
                Debug.Log("No Ability");
            }
        }
    }
    // Collision Checking...
    private void OnCollisionEnter(Collision collision)
    {
        if (allowOutOfPlay != true)
        {
            if (isoutofplay(collision) == true)
            {
                isOutOfPlay = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (GetComponent<Rigidbody>().angularDrag < 40 && isMoving == true)
            {
                rb.angularDrag += 2;
                canResetDrag = true;
            }
            else if(isMoving == false && canResetDrag == true)
            {
                rb.angularDrag = 0.05f;
                canResetDrag = false;
            }
        }
    }

    // Trigger Checking...
    void OnTriggerEnter(Collider other)
    {
        // if the game object enters in the trigger area of another object with this tag do this...
        if (other.gameObject.CompareTag("Hole"))
        {
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            //Input.ResetInputAxes ();
            scorescript.scoreUp();
        }
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        // if the game object enters in the trigger area of another object with this tag do this...
        if (other.gameObject.CompareTag("ability"))
        {
            if (slotEmpty == true)
            {
                Debug.Log("Hit Ability");
                AbilityNumber = other.gameObject.GetComponent<PickupFloat>().AbilityNumber;
                slotEmpty = false;
                AbilityActive = true;
                other.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    private Vector3 GetDirection()
    {
        RaycastHit hit;
        Vector3 mousePos = new Vector3(0f, 0f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            mousePos = hit.point;
        }
        mousePos = mousePos - transform.position;
        return mousePos;
    }

    private Vector3 RotateWithView()
    {
        if (camTransform != null)
        {
            Vector3 dir = camTransform.InverseTransformDirection(MoveVector);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized * MoveVector.magnitude;
        }
        else
        {
            camTransform = Camera.main.transform;
            return MoveVector;
        }
    }

    private Vector3 getMousePosition()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        if (dir.magnitude > 1)
            dir.Normalize();
        return dir;
    }

    private void outofplay()
    {
        isOutOfPlay = true;
    }

    private bool isoutofplay(Collision collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            return true;
        }
        else
            return false;
    }

    // Ability Function

    private void Boost()
    {
        forceMax = 1600.0f;
    }

    private void Jump()
    {
        Debug.Log("Jump");
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
        forceMax = 1100.0f;
        AbilityNumber = 0;
        slotEmpty = true;
    }
    IEnumerator Wait()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
