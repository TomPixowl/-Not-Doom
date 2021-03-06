using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject presetTarget;
    [SerializeField] GameObject presetPlatform;
    [SerializeField] TextMeshProUGUI TimeUI;
    [SerializeField] TextMeshProUGUI TargetRemainingUI;
    private int timeCounter;
    [SerializeField] int maxTargets;
    [SerializeField] int maxPlatforms;
    public int RemainingTargets;
    [SerializeField] Light light;
    [SerializeField] Light presetLight;

    void Awake()
    {
        for (int i = 0; i < maxTargets; i++)
        {
            Vector3 pos = new Vector3(Random.Range(150, 360), Random.Range(20, 100), Random.Range(115, 420));
            Instantiate(presetTarget, pos, Quaternion.identity);
        }
        RemainingTargets = maxTargets;

        for (int i = 0; i < maxPlatforms; i++)
        {
            Vector3 pos = new Vector3(Random.Range(150, 360), Random.Range(50, 100), Random.Range(115, 420));
            Instantiate(presetPlatform, pos, Quaternion.identity);
        }

        light = presetLight;
    }



    void Update()
    {
       
        TimerUpdater();
        TargetUpdater();
        light = presetLight;
        if(RemainingTargets <= 0)
        {
            EndGame();
        }

    }

    void EndGame()
    {
        SceneManager.LoadScene("End Screen", LoadSceneMode.Single);
    }

    void TimerUpdater()
    {
        timeCounter = (int)Time.realtimeSinceStartup;
        TimeUI.text = "Time: " + (timeCounter);
    }

    void TargetUpdater()
    {
        TargetRemainingUI.text = "Remaining Targets: " + RemainingTargets + "/" + maxTargets;
    }

}
