using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerBody;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float rotationSpeed;
    private bool playerJumpLimit;

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerJumpLimit = false;
    }
        
    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Mouse0)) Fire();
        if (Input.GetKeyDown(KeyCode.Space) && !playerJumpLimit) Jump();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerBody.velocity += transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerBody.velocity -= transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerBody.velocity += transform.right * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerBody.velocity -= transform.right * speed;
        }
    }

    void Fire()
    {
        
    }
    void Jump()
    {
        playerBody.velocity += transform.up * jumpSpeed;
        playerJumpLimit = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        playerJumpLimit = false;
    }
}


