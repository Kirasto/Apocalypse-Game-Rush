using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public bool isBroken = false;
    public string gameName;
    public float goal = 1000;
    public float current = 0;

    public float pointPerSec = 1;
    public float pointPerClick = 1;

    [SerializeField]
    TextMesh nameText;

    private void Awake()
    {
        nameText = transform.Find("Name").GetComponent<TextMesh>();
        nameText.text = gameName;
    }
}
