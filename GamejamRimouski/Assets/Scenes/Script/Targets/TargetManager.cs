using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    public GameObject arrow;

    private GameObject activeTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrow.SetActive(true);
        if (activeTarget == null)
        {
            //arrow.SetActive(false);
        }

        if (activeTarget != null)
        {
            
            Debug.Log(activeTarget.transform.position);


            var q = Quaternion.LookRotation(arrow.transform.position - activeTarget.transform.position);
            arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, q, 360);

        }

        
    }
    public void setActiveTarget(GameObject target)
    {
        this.activeTarget = target;
        Debug.Log(activeTarget);
    }
}
