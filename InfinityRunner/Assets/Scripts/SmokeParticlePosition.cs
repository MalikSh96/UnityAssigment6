using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticlePosition : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public Rigidbody rb;
    private float moveSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + offset;
        moveSpeed = player.GetComponent<CharacterBehaviour>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * -8f;
    }
}
