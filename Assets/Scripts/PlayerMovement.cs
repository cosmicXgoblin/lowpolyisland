using System.Collections;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Ground")]             
    public float moveSpeed;
    public float runSpeed;
    private float actualSpeed;
    public float groundDrag;

    [Header("Movement Air")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode submitKey = KeyCode.E;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode forwardKey = KeyCode.Q;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    public float range = 0.0001f;

    [Header("Steps")] // every half second
   // private float nextActionTime = 0.5f; //not in use anymore
    public float period = 1f;

    [Header("Other")]
    public Transform orientation;
    [SerializeField] GameObject UI;
    public float rotBefore;
    public LayerMask thisIsDeath;
    public GameObject Collider;
    public GameObject UiManagement;

    // keyboardinputs
    float horizontalInput;
    float verticalInput;

    // movement direction
    Vector3 moveDirection;
    Rigidbody rb;

    //for isWalking
    public Vector3 oldpos;
    public Vector3 newpos;
    public bool isWalking;



    private void Start()
    {
        // first tings first: we are getting the rigidbody and freeze it's rotation, in addition
        // ... we are also setting our readyToJump bool to true to start it's function
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

        // here we are implementing the coroutine for our position check, so we can play footsteps
        // ... whether we are walking or not.
        oldpos = this.gameObject.transform.position;
        StartCoroutine(CheckPosition());
        StartCoroutine(playFootsteps());
        // Debug.Log("Position should be checked");
    }

    private void Update()
    {
        // this is our ground check : we cast a ray to the ground. if it hit's something that is
        // ... labeled with groound, it's setting grounded to true
        Vector3 direction = Vector3.down;
        grounded = Physics.Raycast(transform.position, direction, playerHeight, whatIsGround);

        // call the keyboardinput
        MyInput();
        // call the speed police if needed
        SpeedControl();

        // handle ground drag (and serve)
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
        
        // if (!grounded)Debug.Log("You are not touching grass right now.");
        // Debug.Log("You are ready to jump:" + readyToJump);

        if (!isWalking)
        {
            // SoundEffectManager.Stop("Steps, Grass");
            SoundEffectManager.Stop();
        }

        //if (Time.time > nextActionTime && isWalking)
        //{
        //    nextActionTime += period;
        //    SoundEffectManager.Play("Steps, Grass");

            //}
    }

    private void FixedUpdate()
    {
        // if the game is paused, we are not interested in the rest of this for the moment.
        // ... therefore. return it is.
        if (UI.GetComponent<MenuManager>().pause == true) return;
        if (UiManagement.GetComponent<UiManager>().tutorialDone == false) return;

        // if a dialogue is playing, we don't want to jump accidently
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            readyToJump = false;
            return;
        }

        //if(isWalking) SoundEffectManager.Play("Steps, Grass");
        MovePlayer();
        Invoke(nameof(ResetJump), jumpCooldown);
    }

    private void MyInput()
    {
        // keyboardinput at it again
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
       // submitKey = GetKeyDown(KeyCode.Q)("Submit");

        // the requirements for jumping
        if (Input.GetKey(jumpKey) && grounded && readyToJump)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    // calculate movement direction
    {
        // always move in the direction you're looking
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // if we are pressing our runKey, we also want running speed
        if (Input.GetKey(runKey))
        {
            // Debug.Log("runKey was pressed");
            actualSpeed = runSpeed;
        }
        else actualSpeed = moveSpeed;

        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * actualSpeed * 10f, ForceMode.Force); //
        }
        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * actualSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    // goa goa mpu ja
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // if you go faster than your movementspeed, you calculate what your max velocity would be and apply it
        // ... i hate math.
        if(flatVel.magnitude > actualSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * actualSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity (so we always jump the exact same height)
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);   // Impulse bc we are only applying the force once
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    // this is a funny one. at least for me, bc it was new. anyhow:
    // ... while we checkPosition, we wait for 0.2 seconds and give the var newpos our current position.
    // ... if the old and the new position is the same, we are clearly not walking, therefore it is set to false.
    // ... if they are not the same, we are walking.
    // ... in the end. we are setting our old position to our new postion and go probably through the loop again.
    IEnumerator CheckPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            newpos = this.gameObject.transform.position;
            //Debug.Log(newpos);

            if (oldpos == newpos)
            {
                isWalking = false;
               // Debug.Log("Player remained idle");
            }
            else if (oldpos != newpos)
            {
                isWalking = true;
                //SoundEffectManager.Play("Steps, Grass");
                //Debug.Log("Player moved");
            }

            oldpos = newpos;
           // Debug.Log(isWalking);
        }
    }
                                        
    
    // at the moment, these two are not in use: it's clashing with the clamping while the dialogue is playing
    // ... and sadly, i do not have the time for it. still proud about the beginning of my solution tho.
    // ... its not much, but it's still nice to see how my brain is more and more working with it.
    //public void CheckOrientation()
    //{
    //    rotBefore = orientation.localEulerAngles.y; ;
    //    Debug.Log("Orientation was checked. rotBefore = " + rotBefore);
    //}
    //public void SetOrientation()
    //{
    //    orientation.Rotate(0, rotBefore, 0);
    //    Debug.Log("Orientation was set. rotBefore = " + rotBefore);
    //}

    // same principle as the position check, did not yield the result i wanted tho
    // ... the footsteps are still playing a little bit after we stopped walking.
    IEnumerator playFootsteps()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            if (grounded && isWalking)
            {
                SoundEffectManager.Play("Steps, Grass");
                //Debug.Log("Step, Step, Step.");
            }
        }
    }

}
