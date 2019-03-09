using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour
{

    public int delayDeletrePrefab = 3;
    private ObjectifManager objectifManager;
    private List<GameObject> targetsInRayon;
    private List<GameObject> targetsAvaible;


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
        //ShowDistanceTarget();
    }

    public void ShowDistanceTarget()
    {
        Debug.Log("ShowDistanceTarget");
        float lastDistance = 0;
        List<GameObject> listTarget = objectifManager.getListTarget();

        for (int i=0;i< listTarget.Count; i++)
        {
            float dist = Vector3.Distance(this.transform.position, listTarget[i].transform.position);
            if (dist > lastDistance)
            {
                lastDistance = dist;
                if(i == 3)
                {
                    targetsAvaible.Add(listTarget[i].gameObject);
                }
            }
        }

        for(int i=0; i< targetsAvaible.Count; i++)
        {
            if (i == Random.Range(0, targetsAvaible.Count))
            {
                target = targetsAvaible[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case State.Wait:
                StartCoroutine(delayBeforeDelete());
                break;
            case State.inCourse:


                break;
        }
    }



    IEnumerator delayBeforeDelete()
    {
        yield return new WaitForSeconds(delayDeletrePrefab);
        objectifManager.deleteObjectifActive();
        Destroy(this.gameObject);
    }
}
