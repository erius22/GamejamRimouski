using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour
{

    public int delayDeletrePrefab = 3;
    private ObjectifManager objectifManager;
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
