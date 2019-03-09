using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public bool goingUp = true;
    public float direction;

    void Start()
    {
        direction = 5;
    }
    
    void Update()
    {
        if(goingUp)
            this.gameObject.transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
        else
            this.gameObject.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);

       
        if (this.gameObject.transform.position.y >= -1.25)
            goingUp = false;

        if (this.gameObject.transform.position.y <= -3.25)
            goingUp = true;

        this.gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * direction);

        if (this.gameObject.transform.eulerAngles.z >= 15 && this.gameObject.transform.eulerAngles.z <= 25)
            direction = -5;
        if (this.gameObject.transform.eulerAngles.z <= 335 && this.gameObject.transform.eulerAngles.z >= 25)
            direction = 5;

    }
}
