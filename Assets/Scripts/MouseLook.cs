using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitvity = 100f;

    [SerializeField] Transform playerBody;
    [SerializeField] Transform anchorPoint;

    private float xRotation = 0f;
    private float anchorRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;
        
        xRotation -= mouseY;
        anchorRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        anchorPoint.rotation = Quaternion.Euler(anchorRotation, 0f, 0f); //Esto no estaria funcionando, el anchor se seta en 0,-90,90 for some reason

        playerBody.Rotate(Vector3.up * mouseX);

    }
}
 