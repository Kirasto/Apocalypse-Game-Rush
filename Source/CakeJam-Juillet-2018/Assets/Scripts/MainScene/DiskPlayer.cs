using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskPlayer : MonoBehaviour {
    [SerializeField]
    Transform diskPosition;
    [SerializeField]
    GameObject disk;
    Animator animator;

    [SerializeField]
    InsertPlan insertPlan;

    public bool isOver = false;
    public bool isOpen;

    [SerializeField]
    AudioClip openAudio;
    [SerializeField]
    AudioClip closeAudio;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        setIsOpen(false, false);
    }

    public void setIsOpen(bool _isOpen, bool playSound = true)
    {
        isOpen = _isOpen;
        animator.SetBool("isOpen", isOpen);
        if (disk.GetComponent<Disk>().positionType == Disk.PositionType.DiskPlayer)
        {
            disk.GetComponent<Collider2D>().enabled = isOpen;
        }
        if (playSound) AudioManager.playSound((isOpen) ? (openAudio) : (closeAudio));
        insertPlan.positionTypeUpdate();
    }

    public void setDiskPosition(Disk disk)
    {
        disk.transform.parent = transform;
        disk.setPosition(diskPosition.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOver = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOver = false;
    }
}
