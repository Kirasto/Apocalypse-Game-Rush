using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSpawnCase : MonoBehaviour {
    [SerializeField]
    GameCase gameCase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameCase.isOver = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameCase.isOver = false;
    }
}
