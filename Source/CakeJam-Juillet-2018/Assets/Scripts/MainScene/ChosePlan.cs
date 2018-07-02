using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChosePlan : Plan {
    [SerializeField]
    GameObject chosePlan;
    [SerializeField]
    GameObject gameInfoPanel;
    [SerializeField]
    Text nameText;
    [SerializeField]
    Text stateText;
    [SerializeField]
    Text progressionText;

    public override void initPlan()
    {
        chosePlan.SetActive(true);
        base.initPlan();
    }

    public override void destroyPlan()
    {
        chosePlan.SetActive(false);
        base.destroyPlan();
    }

    public void onGameOver(Game game)
    {
        if (!Manager.instance.gameOn) return;
        gameInfoPanel.SetActive(true);

        nameText.text = game.gameName;
        stateText.text = (game.isBroken) ? ("Broken") : ("Good");
        progressionText.text = ((game.current * 100) / game.goal).ToString("F1") + "%";
    }

    public void onGameExit()
    {
        if (!Manager.instance.gameOn) return;
        gameInfoPanel.SetActive(false);
    }
}
