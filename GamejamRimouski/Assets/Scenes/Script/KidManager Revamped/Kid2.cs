using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid2 : MonoBehaviour
{
    public bool embarqued = false;
    public float timeAlive = 30f;
    public int timeAdd = 15;
    public int scoreAdd = 5;

    private KidSpawnerManager spawner;
    private GameObject gameManager;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("GameManager");
        spawner = GameObject.Find("Spawner").GetComponent<KidSpawnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!embarqued)
        {
            timeAlive -= Time.deltaTime;
        }
        if(timeAlive <= 0)
        {
            spawner.removeKids();
            Destroy(this.gameObject);
        }
    }

    public void embark()
    {
        EventManager.TriggerEvent("addTime", new Hashtable() { { "addTime", timeAdd } });
        embarqued = true;
    }

    public void disembark()
    {
        EventManager.TriggerEvent("addScore", new Hashtable() { { "addScore", scoreAdd } });
        timeAlive = 20f;
        embarqued = false;
    }
}
