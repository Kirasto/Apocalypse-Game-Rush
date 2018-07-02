using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskPlayerTop : MonoBehaviour {
    [SerializeField]
    DiskPlayer diskPlayer;
    [SerializeField]
    Disk disk;

    private void OnMouseDown()
    {
        if (!Manager.instance.gameOn) return;
        diskPlayer.setIsOpen(!diskPlayer.isOpen);
    }
}
