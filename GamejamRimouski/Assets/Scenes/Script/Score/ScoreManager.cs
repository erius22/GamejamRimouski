using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score : " + score.ToString();
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score : " + score.ToString();
    }
}
