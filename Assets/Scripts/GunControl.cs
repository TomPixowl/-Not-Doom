using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    [SerializeField] Rigidbody bulletPreset;
    [SerializeField] float speed = 200;
    [SerializeField] int bulletDuration;
    [SerializeField] Transform anchorPoint;
    private Rigidbody bullet;
    [SerializeField] float hookRange;
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject wireHookPreset;
    [SerializeField] Rigidbody playerBody;
    [SerializeField] float hookSpeed = 200;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            hook();
        }
    }

    void shoot()
    {

        Vector3 currentPos;

        for (int i = 0; i < 3; i++)
        {
            currentPos = anchorPoint.transform.position;
            switch (i)
            {
                case 0:
                    bullet = Instantiate(bulletPreset, currentPos, Quaternion.identity);
                    break;
                case 1:
                    bullet = Instantiate(bulletPreset, currentPos += (Vector3.forward * 2), Quaternion.identity);
                    break;
                case 2:
                    bullet = Instantiate(bulletPreset, currentPos += (Vector3.back * 2), Quaternion.identity);
                    break;
                default:
                    break;
            }
            bullet.velocity = anchorPoint.transform.forward * speed;
            Destroy(bullet.gameObject, bulletDuration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);    
    }

    private void hook()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(mainCam.transform.position,mainCam.transform.forward,out hitInfo, hookRange))
        {
            //Instantiate(wireHookPreset, anchorPoint.position, anchorPoint.rotation);

            if(hitInfo.transform.tag == "platform")
            {
                playerBody.velocity = mainCam.transform.forward * hookSpeed;
            }
            
        }
    }

}
