using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerBody;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    private bool playerJumpLimit;
    [SerializeField] BoxCollider platformColl;
    private Collision savedCollision;

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerJumpLimit = false;
    }
        

    void Update()
    {
        Movement();
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

    void Jump()
    {
        playerBody.velocity += transform.up * jumpSpeed;
        playerJumpLimit = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "floor" || collision.transform.tag == "platform") playerJumpLimit = false;

        if(collision.transform.tag == "platform")
        {
            Vector3 platPos = collision.transform.position;
            //resuelto muy cavernicola
            if (savedCollision != collision)
            {
                playerBody.position = (platPos + new Vector3(0, 15, 0));
            }
            playerBody.velocity = Vector3.zero;
            savedCollision = collision;

        }
    }
}


