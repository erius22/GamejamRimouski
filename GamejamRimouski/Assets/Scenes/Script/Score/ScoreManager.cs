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
    }

    public void AddScore(Hashtable data)
    {

        score += scoreAdd;
        EventManager.TriggerEvent("score", new Hashtable() { { "score", score } });

    }
}
