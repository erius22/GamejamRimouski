using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidSpawnerManager : MonoBehaviour
{
    public GameObject kidPrefab;
    public List<Transform> spawnPointList;
    public List<GameObject> targetList;
    public int maxKids = 3;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private int numberOfKids;

    // Start is called before the first frame update
    void Start()
    {
        numberOfKids = 0;
        float t_InitialSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        StartCoroutine(SpawnKid(t_InitialSpawnTime));
    }

    public void removeKids()
    {
        numberOfKids--;
    }

    private IEnumerator SpawnKid(float a_Delay)
    {
        yield return new WaitForSeconds(a_Delay);

        int spawnPointID = Random.Range(0, spawnPointList.Count);

        Debug.Log(spawnPointList[spawnPointID].transform.position);
        if (numberOfKids < maxKids)
        {
            GameObject kid = Instantiate(kidPrefab,spawnPointList[spawnPointID].transform.position,Quaternion.identity);
            kid.transform.position = spawnPointList[spawnPointID].transform.position;

            Debug.Log("instantiate : " + kid.transform.position);

            numberOfKids++;
        }

        float t_NewDelay = Random.Range(minSpawnTime, maxSpawnTime);
        
        StartCoroutine(SpawnKid(t_NewDelay));
        
    }
    
    
}
