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
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotationSpeed, Space.World);
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


