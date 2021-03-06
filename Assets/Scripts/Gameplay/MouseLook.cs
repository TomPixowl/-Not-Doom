using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitvity = 100f;
    [SerializeField] Transform playerBody;
    [SerializeField] Transform anchorPoint;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;
        
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        anchorPoint.rotation = transform.rotation;
    }
}
 