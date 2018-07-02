using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlan : Plan {
    [SerializeField]
    GameObject gamePanel;
    [SerializeField]
    GameController gameController;

    public override void initPlan()
    {
        gamePanel.SetActive(true);
        gameController.init();
        base.initPlan();
    }

    public override void destroyPlan()
    {
        gamePanel.SetActive(false);
        gameController.destroy();
        base.destroyPlan();
    }

    public void onBackButton_Clicked()
    {
        PlansManager.instance.openPlan("Insert");
    }
}
