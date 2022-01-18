using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextControl : MonoBehaviour
{
    [SerializeField] Transform arrowPos;
    [SerializeField] GameObject Cube;
    bool menuOn = false;


    void Start()
    {

    }


    void Update()
    {
        if(Cube.transform.localScale == Vector3.zero)
        {
            StartCoroutine(Example());
        }

        if (menuOn)
        {
            checkInputs();
            checkMenuInputs();
        }
        

    }

    void checkInputs()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
        {
            switch (arrowPos.localPosition.y)
            {
                case -38:
                    arrowPos.localPosition = new Vector3 (-61,-128,0);
                    return;
                case -128:
                    arrowPos.localPosition = new Vector3(-61, -216, 0);
                    return;
                case -216:
                    arrowPos.localPosition = new Vector3(-61, -294, 0);
                    return;
                case -294:
                    arrowPos.localPosition = new Vector3(-61, -38, 0);
                    return;
                default:
                    return;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            switch (arrowPos.localPosition.y)
            {
                case -38:
                    arrowPos.localPosition = new Vector3(-61, -294, 0);
                    return;
                case -128:
                    arrowPos.localPosition = new Vector3(-61, -38, 0);
                    return;
                case -216:
                    arrowPos.localPosition = new Vector3(-61, -128, 0);
                    return;
                case -294:
                    arrowPos.localPosition = new Vector3(-61, -216, 0);
                    return;
                default:
                    return;
            }
        }
    }

    void checkMenuInputs()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            switch (arrowPos.localPosition.y)
            {
                case -38:
                    SceneManager.LoadScene("Gameplay",LoadSceneMode.Single);
                    return;
                case -128:
                    Debug.LogError("RECORDS");
                    //Mostrar records guardados de players anteriores, agregar "save name" al terminar el nivel
                    return;
                case -216:
                    Debug.LogError("OPTION");
                    //Cambio de color de crosshair, sonido, music, difficulty?
                    return;
                case -294:
                    Application.Quit();
                    return;
                default:
                    return;
            }
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(1);
        menuOn = true;
    }
}
