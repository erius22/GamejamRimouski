using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeat : MonoBehaviour
{
    public bool seatAvailable = true;
    public bool isOnBeluga = false;
    
    public GameObject client;
    public GameObject positionSit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "kid" && !client.GetComponent<Kid2>().arrived)
        {
            client.GetComponent<Kid2>().animator.SetTrigger("climb");
            client.GetComponent<Kid2>().isSwming = false;
            isOnBeluga = true;
            client.transform.parent = this.transform;

        }
    }

    private void Update()
    {
        if (isOnBeluga)
        {
            client.transform.position = positionSit.transform.position;
        }
    }


}
