using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 5f;

    public float jumpSpeed = 20.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    //Start is called before the first frame update
    void Start()
    {
        //since the script is applied to the player
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }


    //does not work
    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }
}

/*
 * Old code:
 * 
 *     //public bool isGrounded;
    //public Rigidbody rb;
 * 
 * 
 * //Player jumps and runs, but never returns to the ground
    void FixedUpdate()
    {
        /*print("Is grounded = " + isGrounded);
        //This moves the player 5m every single second
        //Time.deltaTime is a time between 2 frames
        controller.Move((Vector3.forward * speed) * Time.fixedDeltaTime);
        if (controller && isGrounded == true)
        {
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                print("jump is pressed");
                 controller.Move((Vector3.up * jumpSpeed) * Time.fixedDeltaTime);
                isGrounded = false;
            }
            moveDirection.y -= gravity * Time.fixedDeltaTime;
         
        }
        controller.Move((Vector3.forward * speed) * Time.fixedDeltaTime);
      }

    
    /*private void OnCollisionEnter(Collision collision)
    {
        print("in collision enter");
        if(collision.transform.tag == "Ground")
        {
            print("in collisionenter if ");
            isGrounded = true;
        }
     
    }
 */
