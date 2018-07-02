using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour {
    [SerializeField]
    DiskPlayer diskPlayer;
    [SerializeField]
    GameCase gameCase;

    [SerializeField]
    InsertPlan insertPlan;
    [SerializeField]
    AudioClip brokenGlassAudio;

    [SerializeField]
    Texture2D diskTexture;
    [SerializeField]
    Texture2D brokenDiskTexture;

    public PositionType positionType;

    public enum PositionType
    {
        Case,
        DiskPlayer,
        Broken,
        Move
    }

    private void setTexture(Texture2D texture)
    {
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public void init()
    {
        Vector3 scale = transform.localScale;
        scale.x = 1f;
        scale.y = 1f;
        transform.localScale = scale;
        if (PlansManager.instance.onGame)
        {
            setPositionType(PositionType.DiskPlayer);
            diskPlayer.setDiskPosition(this);
            gameObject.SetActive(true);
        }
        else if (PlansManager.instance.game.isBroken)
        {
            setTexture(brokenDiskTexture);
            setPositionType(PositionType.Broken);
            gameObject.SetActive(false);
        }
        else
        {
            setTexture(diskTexture);
            setPositionType(PositionType.Case);
            gameObject.SetActive(false);
        }
    }

    public void setPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    private void OnMouseDown()
    {
        if (!diskPlayer.isOpen && positionType == PositionType.DiskPlayer) { return; }
        if (positionType == PositionType.Broken || !Manager.instance.gameOn) { return; }
        setPositionType(PositionType.Move);
        transform.parent = null;
    }

    private void OnMouseDrag()
    {
        if (!diskPlayer.isOpen && positionType == PositionType.DiskPlayer) { return; }
        if (positionType == PositionType.Broken || !Manager.instance.gameOn) { return; }
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -1;
        transform.position = pos;
    }

    private void setPositionType(PositionType type)
    {
        positionType = type;
        insertPlan.positionTypeUpdate();
    }

    private void OnMouseUp()
    {
        if (!diskPlayer.isOpen && positionType == PositionType.DiskPlayer) { return; }
        if (positionType == PositionType.Broken || !Manager.instance.gameOn) { return; }
        if (diskPlayer.isOver && diskPlayer.isOpen)
        {
            setPositionType(PositionType.DiskPlayer);
            diskPlayer.setDiskPosition(this);
        }
        else if (gameCase.isOver)
        {
            setPositionType(PositionType.Case);
            gameCase.setDiskPosition();
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = 0.8f;
            scale.y = 0.8f;
            transform.localScale = scale;
            setPositionType(PositionType.Broken);
            PlansManager.instance.game.isBroken = true;

            AudioManager.playSound(brokenGlassAudio);
            setTexture(brokenDiskTexture);
        }
    }
}
