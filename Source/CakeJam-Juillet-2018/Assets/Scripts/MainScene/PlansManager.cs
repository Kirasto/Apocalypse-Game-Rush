using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlansManager : MonoBehaviour {

    public static PlansManager instance;

    [SerializeField]
    GameObject insertPlan;
    [SerializeField]
    GameObject chosePlan;
    [SerializeField]
    GameObject gamePlan;

    GameObject currentPlan = null;
    [SerializeField]
    CameraController cameraController;

    public Game game;
    public bool onGame = false;

    public void Awake()
    {
        instance = this;
        openPlan("Chose");
    }

    public void openPlan(string planName)
    {
        if (currentPlan != null)
        {
            currentPlan.GetComponent<Plan>().destroyPlan();
        }
        switch (planName)
        {
            case "Insert":
                cameraController.setPosition(insertPlan);
                currentPlan = insertPlan;
                break;
            case "Chose":
                onGame = false;
                cameraController.setPosition(chosePlan);
                currentPlan = chosePlan;
                break;
            case "Game":
                onGame = true;
                cameraController.setPosition(gamePlan);
                currentPlan = gamePlan;
                break;
            default:
                return;
        }
        currentPlan.GetComponent<Plan>().initPlan();
    }

    public void onQuitButton_Clicked()
    {
        SceneManager.LoadScene(0);
    }
}
