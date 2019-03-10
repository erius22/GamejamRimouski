using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 45;
        EventManager.AddListner("addTime", AddTime);

    }

    // Update is called once per frame
    void Update()
    {
        time -=Time.deltaTime;
        int b = (int)time;
        EventManager.TriggerEvent("countDown", new Hashtable() { { "countDown", b } });

        if (time <= 0)
        {
            EventManager.TriggerEvent("setScoreParam", null);
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
        }
        
    }
    
    public void AddTime(Hashtable data)
    {
        int addedTime = (int)data["addTime"];

        time += addedTime;
    }
}
