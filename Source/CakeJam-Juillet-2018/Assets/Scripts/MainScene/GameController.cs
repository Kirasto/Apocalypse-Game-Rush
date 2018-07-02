using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField]
    Text progressionText;

    Game game;

    public bool gameOn = false;

    [SerializeField]
    List<AudioClip> gameVictoryAudio;

    public void init()
    {
        game = PlansManager.instance.game;
        updateProgression();
        gameOn = true;
    }

    public void destroy()
    {
        gameOn = false;
    }

    void updateProgression()
    {
        progressionText.text = ((game.current * 100) / game.goal).ToString("F1") + "%";
    }

    void Update()
    {
        if (!gameOn) { return; }
        if (game.current >= game.goal)
        {
            game.current = game.goal;
            updateProgression();
            gameOn = false;
            AudioManager.playSound(gameVictoryAudio[Random.Range(0, gameVictoryAudio.Count)]);
            return;
        }
        game.current += game.pointPerSec * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            game.current += game.pointPerClick;
        }
        updateProgression();
    }
}
