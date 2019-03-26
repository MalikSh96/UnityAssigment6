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
        controller.Move((Vector3.forward * speed) * Time.deltaTime);
    }
}
