using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject presetTarget;
    [SerializeField] Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 11; i++)
        {
            Vector3 pos = new Vector3(Random.Range(130, 360), Random.Range(9,100), Random.Range(115, 480));
            Instantiate(presetTarget, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
