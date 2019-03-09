using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifManager : MonoBehaviour
{

    //public List<GameObject> listObjectif;
    public List<GameObject> listTarget;
    public GameObject prefabKid;
    public GameObject hitBoxSpawnKid;

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
