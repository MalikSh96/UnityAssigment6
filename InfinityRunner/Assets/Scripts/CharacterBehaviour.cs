using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;

    private float speed = 1.0F;

    public float jumpSpeed = 20.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection; //= Vector3.zero;

    bool isGrounded;

    //Start is called before the first frame update
    void Start()
    {
        //since the script is applied to the player
        controller = GetComponent<CharacterController>();
    }

    //Player jumps and runs, but never returns to the ground
    void FixedUpdate()
    {
        print("Is grounded = " + isGrounded);
        //This moves the player 5m every single second
        //Time.deltaTime is a time between 2 frames
        controller.Move((Vector3.forward * speed) * Time.fixedDeltaTime);
        if (controller && isGrounded == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                print("jump is pressed");
                controller.Move((Vector3.up * jumpSpeed) * Time.fixedDeltaTime);
                //isGrounded = false;
            }
            moveDirection.y -= gravity * Time.fixedDeltaTime;
         
        }
        controller.Move((Vector3.forward * speed) * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("in collision enter");
        if(collision.transform.tag == "ground")
        {
            print("in collisionenter if ");
            isGrounded = true;
        }
     
    }
}
