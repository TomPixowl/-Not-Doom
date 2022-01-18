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
    [SerializeField] Rigidbody playerBody;
    [SerializeField] float hookSpeed = 200;
    [SerializeField] LineRenderer wireHook;



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


        if (wireHook.GetPosition(0) != Vector3.zero)
        {
            StartCoroutine(Example());
        }
    }

    void shoot()
    {
        Vector3 currentPos;
        currentPos = anchorPoint.transform.position;
        bullet = Instantiate(bulletPreset, currentPos, Quaternion.identity);
        bullet.velocity = anchorPoint.transform.forward * speed;
        Destroy(bullet.gameObject, bulletDuration);
         
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

            if(hitInfo.transform.tag == "platform")
            {
                wireHook.SetPosition(0, anchorPoint.position);
                wireHook.SetPosition(1, hitInfo.transform.position);
                
                playerBody.velocity = mainCam.transform.forward * hookSpeed;
            }
            
        }

    }

    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(1);
        wireHook.SetPosition(0, Vector3.zero);
        wireHook.SetPosition(1, Vector3.zero);

    }

}
