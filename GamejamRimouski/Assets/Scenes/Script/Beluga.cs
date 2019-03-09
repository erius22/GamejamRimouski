using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beluga : MonoBehaviour
{
    public ObjectifManager objectifManager;

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "kid")
        {
            collider.GetComponent<Kid>().deleteKid();
            objectifManager.spawnKid();
        }
    }

}
