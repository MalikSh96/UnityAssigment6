using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Links used: 
https://www.youtube.com/watch?v=w3nywthMvQA&list=PLLH3mUGkfFCXps_IYvtPcE9vcvqmGMpRK&index=2
 */
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 8.0f;



    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    //--------OLD CODE THAT MOVES THE PLAYER-------------
    //Start is called before the first frame update
    void Start()
    {
        //since the script is applied to the player
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //This moves the player 5m every single second
        //Time.deltaTime is a time between 2 frames
        //if statement breaks the movement
        //if (controller.isGrounded)
        //{
            controller.Move((Vector3.forward * speed) * Time.deltaTime);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        //}
    }


    //----------------NEW CODE, DOES NOT WORK, PLAYER FALL THROUGH TERRAIN------------
    //void Start()
    //{
    //    controller = GetComponent<CharacterController>();

    //    // let the gameObject fall down
    //    gameObject.transform.position = new Vector3(0, 0, 0);
    //}

    //void Update()
    //{
    //    if (controller.isGrounded)
    //    {
    //        // We are grounded, so recalculate
    //        // move direction directly from axes

    //        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    //        moveDirection = transform.TransformDirection(moveDirection);
    //        moveDirection = moveDirection * speed;

    //        if (Input.GetButton("Jump"))
    //        {
    //            moveDirection.y = jumpSpeed;
    //        }
    //    }

    //    // Apply gravity
    //    moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

    //    // Move the controller
    //    controller.Move(moveDirection * Time.deltaTime);
    //}





}
