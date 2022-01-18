using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endOrb : MonoBehaviour
{
    private float rotationY;
    private float rotationZ;
    int scalingFramesLeft;
    [SerializeField] int expandFrameAmount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotationY++;
        rotationY = rotationY - 0.8f;
        rotationZ = rotationY / 2;
        transform.localRotation = Quaternion.Euler(0f, rotationY, rotationZ);
        scalingFramesLeft = expandFrameAmount;
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(48, 48, 48), Time.deltaTime * 10);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.Quit();
        }
    }
}
