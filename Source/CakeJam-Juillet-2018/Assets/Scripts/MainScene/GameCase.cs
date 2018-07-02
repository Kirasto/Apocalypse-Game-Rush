using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCase : MonoBehaviour {

    [SerializeField]
    Disk disk;
    Vector3 position;

    [SerializeField]
    Texture2D closeTexture;
    [SerializeField]
    Texture2D openTexture;

    [SerializeField]
    Transform diskSpawn;
    [SerializeField]
    AudioClip openAudio;

    bool isOpen = false;
    public bool isOver = false;

    public void Awake()
    {
        position = transform.position;
    }

    private void setTexture(Texture2D texture)
    {
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public void StartPlacing()
    {
        isOpen = false;
        disk.gameObject.SetActive(false);
        setTexture(closeTexture);
        transform.position = position;
        if (PlansManager.instance.onGame) openCase(false);
        disk.init();
    }

    public void setDiskPosition()
    {
        disk.transform.parent = transform;
        disk.setPosition(diskSpawn.position);
    }

    private void openCase(bool playSound = true)
    {
        setTexture(openTexture);
        setDiskPosition();
        disk.gameObject.SetActive(true);
        disk.positionType = Disk.PositionType.Case;
        disk.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (playSound) AudioManager.playSound(openAudio);
    }

    private void OnMouseDown()
    {
        if (!isOpen && Manager.instance.gameOn)
        {
            isOpen = true;
            openCase();
        }
    }
}
