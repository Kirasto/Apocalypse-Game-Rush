using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreController : MonoBehaviour {

    public static ScoreController instance = null;

    [SerializeField]
    float highScore;
    [SerializeField]
    float lastScore;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            load();
        }
        else
        {
            instance.save();
            Destroy(gameObject);
        }
    }

    void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/ScoreInfo.data");

        ScoreData data = new ScoreData();
        data.highScore = highScore;
        data.lastScore = lastScore;

        bf.Serialize(file, data);
        file.Close();

        if (ScorePanel.instance != null)
        {
            ScorePanel.instance.updateScore(highScore, lastScore);
        }
    }

    void load()
    {
        if (File.Exists(Application.persistentDataPath + "/ScoreInfo.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ScoreInfo.data", FileMode.Open);
            ScoreData data = (ScoreData)bf.Deserialize(file);
            file.Close();

            highScore = data.highScore;
            lastScore = data.lastScore;
        }
        else
        {
            highScore = 0;
            lastScore = 0;
        }

        if (ScorePanel.instance != null)
        {
            ScorePanel.instance.updateScore(highScore, lastScore);
        }
    }

    public void onGameIsOver(float score)
    {
        if (score > highScore) highScore = score;
        lastScore = score;
    }
}

[Serializable]
class ScoreData
{
    public float highScore;
    public float lastScore;
}
