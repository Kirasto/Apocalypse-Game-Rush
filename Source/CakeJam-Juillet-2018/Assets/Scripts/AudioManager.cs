using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public static AudioSource source;

    public static bool stopAtNextBool = false;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public static void playSound(AudioClip audio, float volume = 1f)
    {
        if (stopAtNextBool)
        {
            source.Stop();
            stopAtNextBool = false;
        }
        source.PlayOneShot(audio, volume);
    }

    public static void stopAtNext()
    {
        stopAtNextBool = true;
    }
}
