using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeat : MonoBehaviour
{
    public bool seatAvailable = true;
    
    public GameObject client;

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "kid")
        {
            client.GetComponent<Kid2>().animator.SetTrigger("climb");
            client.transform.parent = this.transform;

        }
    }


}
