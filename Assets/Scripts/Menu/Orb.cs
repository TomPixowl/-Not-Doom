using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Orb : MonoBehaviour
{
    private float rotationY;
    private float rotationZ;
    bool enterPressed;
    int scalingFramesLeft;
    [SerializeField] int expandFrameAmount;
    [SerializeField] TextMeshProUGUI startTxt;
    [SerializeField] Canvas menuCanvas;
    [SerializeField] GameObject Cube;
    // Start is called before the first frame update
    void Start()
    {
        enterPressed = false;
        menuCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotationY++;
        rotationY = rotationY - 0.8f;
        rotationZ = rotationY / 2;
        transform.localRotation = Quaternion.Euler(0f, rotationY, rotationZ);
        Cube.transform.localRotation = Quaternion.Euler(0f, -rotationY, -rotationZ);
        onButtonPress();
    }

    void onButtonPress()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !enterPressed)
        {
            Cube.transform.localScale = Vector3.zero;
            scalingFramesLeft = expandFrameAmount;
        }

        if (scalingFramesLeft > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(48, 48, 48),Time.deltaTime * 10);
            scalingFramesLeft--;
            enterPressed = true;
            startTxt.fontSize = 0;
            menuCanvas.enabled = true;
        }

    }
}
