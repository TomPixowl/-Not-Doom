using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "target")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<GameManager>().RemainingTargets--;
        }
    }
}
