using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimation : MonoBehaviour
{
    public bool goingUp = false;
    public float direction;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        direction = 5;
    }
    
    void Update()
    {
        if(goingUp)
            rectTransform.localPosition += new Vector3(0, 1 * Time.deltaTime * 30, 0);
        else
            rectTransform.localPosition -= new Vector3(0, 1 * Time.deltaTime * 30, 0);

       
        if (rectTransform.localPosition.y >= 300)
            goingUp = false;

        if (this.gameObject.transform.position.y <= 150)
            goingUp = true;

        this.gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * direction);

        if (this.gameObject.transform.eulerAngles.z >= 15 && this.gameObject.transform.eulerAngles.z <= 25)
            direction = -5;
        if (this.gameObject.transform.eulerAngles.z <= 335 && this.gameObject.transform.eulerAngles.z >= 25)
            direction = 5;

    }
}
