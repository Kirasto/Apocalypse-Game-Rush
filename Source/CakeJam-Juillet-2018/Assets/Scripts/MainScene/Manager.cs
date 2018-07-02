using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public static Manager instance;

    [SerializeField]
    float timeLeft = 60;
    [SerializeField]
    Text timeText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    GameObject scorePanel;
    [SerializeField]
    GameController gameController;

    bool timerOn = true;
    public bool gameOn = true;

    private void Awake()
    {
        instance = this;
        updateTimeText();
    }

    private void updateTimeText()
    {
        timeText.text = timeLeft.ToString("F0");
    }

    private void Update()
    {
        if (!timerOn) { return; }
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            timerOn = false;
            gameFinish();
        }
        updateTimeText();
    }

    private void gameFinish()
    {
        gameOn = false;
        gameController.gameOn = false;
        scorePanel.SetActive(true);
        float score = getScore();
        scoreText.text = score.ToString("F0") + " points";
        GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>().onGameIsOver(score);
    }

    private float getScore()
    {
        float score = 0;

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Game");
        foreach (GameObject go in gos)
        {
            Game game = go.GetComponent<Game>();
            if (!game.isBroken)
            {
                score += game.current;
                if (game.current >= game.goal)
                {
                    score += game.goal / 10;
                }
            }
        }
        return score;
    }

    public void onReturnToMenu_Clicked()
    {
        SceneManager.LoadScene(0);
    }
}
