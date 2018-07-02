using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelector : MonoBehaviour {
    Game game;
    [SerializeField]
    GameObject highLight;

    [SerializeField]
    ChosePlan chosePlan;
    [SerializeField]
    InsertPlan insertPlan;

    private void Awake()
    {
        game = GetComponent<Game>();
    }

    private void OnMouseEnter()
    {
        if (!Manager.instance.gameOn) return;
        highLight.SetActive(true);
        chosePlan.onGameOver(GetComponent<Game>());
    }

    private void OnMouseExit()
    {
        if (!Manager.instance.gameOn) return;
        highLight.SetActive(false);
        chosePlan.onGameExit();
    }

    private void OnMouseDown()
    {
        if (!Manager.instance.gameOn) return;
        PlansManager.instance.game = GetComponent<Game>();
        PlansManager.instance.openPlan("Insert");
    }
}
