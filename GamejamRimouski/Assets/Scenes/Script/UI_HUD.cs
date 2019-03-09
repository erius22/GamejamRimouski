using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HUD : MonoBehaviour
{
    public Text countDownText;
    public Text scoreText;


    private void Start()
    {
        EventManager.AddListner("countDown", OnCountDown);
        EventManager.AddListner("score", OnScore);

    }

    private void OnCountDown(Hashtable data)
    {
        int countDown = (int)data["countDown"];

        countDownText.text =  countDown.ToString();
    }

    private void OnScore(Hashtable data)
    {
        int score = (int)data["score"];
        scoreText.text = score.ToString();
    }

}
