using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifManager : MonoBehaviour
{

    //public List<GameObject> listObjectif;
    public List<GameObject> listTarget;
    public GameObject prefabKid;
    public GameObject hitBoxSpawnKid;
    public GameObject player;
    public GameObject arrow;


    private Vector3 targetDirection;
    private GameObject ActiveTarget;
    private Vector3 center;
    public Vector3 size;


    // Start is called before the first frame update
    public int objectifMax = 3;
    private int objectifActive = 0;

    void Start()
    {
        spawnKid();
    }

    private void Update()
    {
        if(objectifActive != 3)
        {
            spawnKid();
        }

        if(ActiveTarget != null)
        {
            Debug.Log(ActiveTarget.transform.position);

            //targetDirection = ActiveTarget.transform.TransformDirection(ActiveTarget.transform.position - arrow.transform.position);
            //float angle = Mathf.Atan2(-targetDirection.x, targetDirection.y) * Mathf.Rad2Deg;
            //arrow.transform.eulerAngles = new Vector3(0, angle);
            //transform.rotation = Quaternion.Slerp(arrow.transform.rotation, Quaternion.LookRotation(ActiveTarget.transform.position), 2);
            //float targetAngle = Mathf.Atan2(t_ShootingDirection.y, t_ShootingDirection.x) * Mathf.Rad2Deg;
            var q = Quaternion.LookRotation(arrow.transform.position - ActiveTarget.transform.position);
            arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, q, 360);

        }
    }
    public void setActiveTarget(GameObject target)
    {
        this.ActiveTarget = target;
    }

    private void spawnKid()
    {
        center = hitBoxSpawnKid.transform.position;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(prefabKid, pos, Quaternion.identity);
        objectifActive++;
    }

    public void deleteActiveKids()
    {
        objectifActive--;
    }

    public List<GameObject> getListTarget()
    {
        return listTarget;
    }
}
