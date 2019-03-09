using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nets : MonoBehaviour
{
    public GameObject net;
    public float speed = 5;
    private bool playerIsNear = false;


    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "player")
        {
            playerIsNear = true;
        }
        
    }
    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "player")
        {
            playerIsNear = false;
        }
    }

    void Update()
    {
        if (playerIsNear && net.transform.position.y >= 1.75)
            net.transform.Translate(0, -1 * Time.deltaTime * speed, 0);
        if(!playerIsNear && net.transform.position.y <= 7)
            net.transform.Translate(0, 1 * Time.deltaTime * speed, 0);
    }
}
