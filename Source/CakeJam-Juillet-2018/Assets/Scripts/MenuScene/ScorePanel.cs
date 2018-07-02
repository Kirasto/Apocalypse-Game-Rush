using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour {
    [SerializeField]
    Text highScoreText;
    [SerializeField]
    Text lastScoreText;

    public static ScorePanel instance;

    private void Awake()
    {
        instance = this;
    }

    public void updateScore(float highScore, float lastScore)
    {
        highScoreText.text = highScore.ToString("F0");
        lastScoreText.text = lastScore.ToString("F0");
    }
}
