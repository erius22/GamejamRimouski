using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        time = 45;
        timeText.text = time.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = time.ToString();

        if(time <= 0)
        {
            //TODO GameOver
        }
        
    }
    
    public void AddTime(int addedTime)
    {
        time += addedTime;
    }
}
