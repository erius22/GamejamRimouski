using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifManager : MonoBehaviour
{

    public List<GameObject> listTarget;
    public GameObject prefabKid;
    public GameObject hitBoxSpawnKid;

    private GameObject ActiveTarget;
    private Vector3 center;


    public int objectifMax = 3;
    private int objectifActive = 0;

    void Start()
    {
        for (int i = 0; i < 3;i++)
        {
            spawnKid();
        }
    }

    public void setActiveTarget(GameObject target)
    {
        this.ActiveTarget = target;
    }

    public void spawnKid()
    {
        center = hitBoxSpawnKid.transform.position;
        Vector3 sizeHitBoxSpawnKid = new Vector3(hitBoxSpawnKid.transform.position.x, hitBoxSpawnKid.transform.position.y, hitBoxSpawnKid.transform.position.z);
        Vector3 pos = center + new Vector3(Random.Range(-sizeHitBoxSpawnKid.x / 2, sizeHitBoxSpawnKid.x / 2), Random.Range(-sizeHitBoxSpawnKid.y / 2, sizeHitBoxSpawnKid.y / 2), Random.Range(-sizeHitBoxSpawnKid.z / 2, sizeHitBoxSpawnKid.z / 2));
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
