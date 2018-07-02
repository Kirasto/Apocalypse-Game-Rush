using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField]
    AudioClip menuAudio;

    private void Start()
    {
        AudioManager.playSound(menuAudio, 1f);
        AudioSource source = GetComponent<AudioSource>();

        source.PlayDelayed(8f);
    }

    public void onPlayButton_Clicked()
    {
        SceneManager.LoadScene(1);
    }

    public void onQuitButton_Clicked()
    {
        Application.Quit();
    }
}
