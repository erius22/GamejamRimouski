using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BoostPower : MonoBehaviour
{

    public float increaseSpeed = 50;
    public float increaseMaxSpeed = 50;

    public float time = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<ControlPlayer>().Boost(increaseSpeed, increaseMaxSpeed, time);

            Destroy(gameObject);
        }
    }
}
