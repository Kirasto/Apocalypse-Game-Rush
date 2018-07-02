using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertPlan : Plan {
    [SerializeField]
    GameCase gameCase;

    [SerializeField]
    GameObject insertPanel;
    [SerializeField]
    Button playButton;
    [SerializeField]
    Button backButton;

    [SerializeField]
    Disk disk;
    [SerializeField]
    DiskPlayer diskPlayer;
    [SerializeField]
    AudioClip brokenDiskAudio;

    public override void initPlan()
    {
        insertPanel.SetActive(true);
        playButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        gameCase.StartPlacing();
        base.initPlan();
    }

    public override void destroyPlan()
    {
        insertPanel.SetActive(false);
        base.destroyPlan();
    }

    public void positionTypeUpdate()
    {
        playButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        if (disk.positionType == Disk.PositionType.DiskPlayer && !diskPlayer.isOpen)
        {
            playButton.gameObject.SetActive(true);
        }
        else if (disk.positionType == Disk.PositionType.Case || disk.positionType ==  Disk.PositionType.Broken)
        {
            backButton.gameObject.SetActive(true);
        }
    }

    public void onBackButton_Clicked()
    {
        if (!Manager.instance.gameOn) return;
        PlansManager.instance.openPlan("Chose");
    }
    public void onPlayButton_Clicked()
    {
        if (PlansManager.instance.game.isBroken)
        {
            AudioManager.playSound(brokenDiskAudio, 2f);
            AudioManager.stopAtNext();
            return;
        }
        if (!Manager.instance.gameOn) return;
        PlansManager.instance.openPlan("Game");
    }
}
