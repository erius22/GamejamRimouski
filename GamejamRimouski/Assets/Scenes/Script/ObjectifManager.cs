using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifManager : MonoBehaviour
{

    //public List<GameObject> listObjectif;
    public List<GameObject> listTarget;
    public GameObject prefabKid;
    public GameObject hitBoxSpawnObjectif;


    private Vector3 center;
    public Vector3 size;

    // Start is called before the first frame update
    public int objectifMax = 3;
    private int objectifActive = 0;

    void Start()
    {
        spawnObjectif();
    }

    private void Update()
    {
        if(objectifActive != 3)
        {
            spawnObjectif();
        }
    }

    private void spawnObjectif()
    {
        center = hitBoxSpawnObjectif.transform.position;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(prefabKid, pos, Quaternion.identity);
        objectifActive++;
    }

    public void deleteObjectifActive()
    {
        objectifActive--;
    }
}
