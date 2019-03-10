using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public int scoreAdd = 15;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        EventManager.AddListner("addScore", AddScore);
        EventManager.AddListner("setScoreParam", OnGameOver);
    }

    private void OnGameOver(Hashtable data)
    {
        PlayerPrefs.SetInt("score", score);

    }
    public void AddScore(Hashtable data)
    {
        int addedScore = (int)data["addScore"];

        score += scoreAdd;

    }
}
