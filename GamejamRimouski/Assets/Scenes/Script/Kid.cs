using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour
{

    public int delayDeletrePrefab = 3;

    public int timeAdd = 15;
    private ObjectifManager objectifManager;
    private List<GameObject> targetsInRayon;
    private List<GameObject> targetsAvaible = new List<GameObject>();


    private GameObject target;
    public enum State
    {
        Wait,
        inCourse
    }

    public State state;

    private void Awake()
    {
        objectifManager = GameObject.Find("GameManager").GetComponent<ObjectifManager>();
    }

    void Start()
    {
        state = State.Wait;
    }

    public void getTargetKid()
    {
        List<GameObject> listTarget = objectifManager.getListTarget();
        for (int i = 0; i < listTarget.Count; i++)
        {
            int compteur = 0;

            for (int j = 0; j < listTarget.Count; j++)
            {
                float dist = Vector3.Distance(this.transform.position, listTarget[i].transform.position);
                float distToCompare = Vector3.Distance(this.transform.position, listTarget[j].transform.position);
                if (dist < distToCompare)
                {
                    compteur++;
                }
            }
            if (compteur < 3 && targetsAvaible.Count < 3)
            {
                targetsAvaible.Add(listTarget[i]);
            }

        }

        for(int i=0; i< targetsAvaible.Count; i++)
        {
            if (i == Random.Range(0, targetsAvaible.Count))
            {
                target = targetsAvaible[i];
                startCourse(target);

                state = State.inCourse;
                break;
            }
        }
    }

    public void startCourse(GameObject target)
    {
        EventManager.TriggerEvent("addTime", new Hashtable() { { "addTime", timeAdd } });
        EventManager.TriggerEvent("addScore", null);

        objectifManager.setActiveTarget(target);

    }

    //Verification si le kid collisione avec le player alors on recupere sa cible
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "player")
        {
            getTargetKid();
        }
    }

        // Update is called once per frame
        void Update()
    {
        switch (state) {
            case State.Wait:
                //StartCoroutine(delayBeforeDelete());
                break;
            case State.inCourse:
                break;
        }
    }

    public void deleteKid()
    {
        objectifManager.deleteActiveKids();
        Destroy(this.gameObject);
    }
}
