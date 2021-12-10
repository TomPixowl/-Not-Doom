using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour
{
    [SerializeField] Transform arrowPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkInputs();
    }

    void checkInputs()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
        {
            switch (arrowPos.position.y)
            {
                case -38:
                    arrowPos.position = new Vector3 (-61,-128,0);
                    return;
                case -128:
                    arrowPos.position = new Vector3(-61, -216, 0);
                    return;
                case -216:
                    arrowPos.position = new Vector3(-61, -294, 0);
                    return;
                case -294:
                    arrowPos.position = new Vector3(-61, -38, 0);
                    return;
                default:
                    return;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            switch (arrowPos.position.y)
            {
                case -38:
                    arrowPos.position = new Vector3(-61, -294, 0);
                    return;
                case -128:
                    arrowPos.position = new Vector3(-61, -38, 0);
                    return;
                case -216:
                    arrowPos.position = new Vector3(-61, -126, 0);
                    return;
                case -294:
                    arrowPos.position = new Vector3(-61, -216, 0);
                    return;
                default:
                    return;
            }
        }
    }
}

//38 top