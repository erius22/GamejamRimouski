using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Camera camera;

    public Vector3 offset;

    public Transform objectToFollow;

    //public float followSpeed = 10;
    public float rotationHorizontalMaxAngle = 50;
    public float rotationVerticalMaxAngle = 20;


    // Start is called before the first frame update
    void Start()
    {
        if (camera == null)
        {
            camera = GetComponentInChildren<Camera>();
        }
    }

    void Update()
    {
        transform.position = objectToFollow.position + offset;
        transform.rotation = objectToFollow.rotation;

        float xRot = rotationVerticalMaxAngle * Input.GetAxis("VerticalCamera");
        float yRot = rotationHorizontalMaxAngle * Input.GetAxis("HorizontalCamera");

        if (xRot != 0 || yRot != 0)
        {
            //transform.Rotate(xRot, yRot, 0.0f);
        }
        // Quaternion counterRotationCam = transform.rotation;
        // counterRotationCam.z = counterRotationCam.z * -1;*/

        //camera.transform.rotation = counterRotationCam;
        //  camera.transform.rotation = (transform.rotation.z, transform.rotation.y, transform.rotation.z * -1);
    }
}
