using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public bool isUse;

    private void Start()
    {
        isUse = false;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && isUse)
        {
            isUse = false;
            PlayerSeat seat = collider.GetComponent<PlayerSeat>();

            seat.client.GetComponent<Kid2>().Disembark();
            seat.seatAvailable = true;
            Debug.Log("Seat available");

        }
    }
}
