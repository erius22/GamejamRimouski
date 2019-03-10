using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            PlayerSeat seat = collider.GetComponent<PlayerSeat>();

            seat.client.GetComponent<Kid2>().Disembark();
            seat.seatAvailable = true;
            Debug.Log("Seat available");

        }
    }
}
