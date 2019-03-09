using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlPlayer : MonoBehaviour
{

    private float forwardSpeedMultiplier;
    [SerializeField] private float upwardSpeedMultiplier = 1;

    private Rigidbody m_rigidbody;
    private float maxSpeed;

    private float forwardSpeed;
    private float movementUpward;

    [SerializeField] private float baseSpeedMultiplier = 10;
    [SerializeField] private float baseMaxSpeed = 200;

    [SerializeField] private float horizontalRotationSpeed = 10;
    [SerializeField] private float verticalRotationSpeed = 1;

    [SerializeField] private float boostTimer;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        forwardSpeedMultiplier = baseSpeedMultiplier;
        maxSpeed = baseMaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        forwardSpeed = Input.GetAxis("Accelerate");

        movementUpward = Input.GetAxis("Upward");


        movementUpward = movementUpward * upwardSpeedMultiplier;
        forwardSpeed = forwardSpeed * forwardSpeedMultiplier;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");




        //transform.localEulerAngles = new Vector3(0, horizontal * horizontalRotationSpeed, 0);

        //transform.Rotate(0, horizontal * horizontalRotationSpeed, 0f);

        transform.Rotate(vertical * verticalRotationSpeed, 0, 0f);

        // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);

        /*
        transform.RotateAround(transform.position, Vector3.right, verticalRotationSpeed * vertical);
        Quaternion q_v = transform.rotation;
        q_v.eulerAngles = new Vector3(q_v.eulerAngles.x, q_v.eulerAngles.y, 0);
        transform.rotation = q_v;
        */

        transform.RotateAround(transform.position, Vector3.up, horizontalRotationSpeed * horizontal);
        Quaternion q_h = transform.rotation;
        q_h.eulerAngles = new Vector3(q_h.eulerAngles.x, q_h.eulerAngles.y, 0);
        transform.rotation = q_h;
        
        //GetComponent<Rigidbody>().AddForce

        //Vector3 movement = new Vector3(0, forwardSpeed, movementUpward * -1);



        //transform.Translate(movement * Time.deltaTime);

    }

    private void FixedUpdate()
    {

        if (boostTimer > 0)
        {
            boostTimer = boostTimer - Time.deltaTime;
        }
        else
        {
            forwardSpeedMultiplier = baseSpeedMultiplier;
            maxSpeed = baseMaxSpeed;
        }


        m_rigidbody.AddForce(transform.forward * forwardSpeed, ForceMode.Acceleration);


        m_rigidbody.AddForce(transform.up * movementUpward, ForceMode.Acceleration);

      
        //transform.Translate(transform.forward * forwardSpeed * Time.deltaTime);

        //m_rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime);

        
        if (m_rigidbody.velocity.magnitude > maxSpeed)
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * maxSpeed;
        }

        
    }

    public void Boost(float boostSpeed, float maxSpeedIncrease, float timer)
    {
        if (boostTimer < 0)
        {
            baseSpeedMultiplier = forwardSpeedMultiplier;
            baseMaxSpeed = maxSpeed;
        }

        boostTimer = boostTimer + timer;
        forwardSpeedMultiplier = forwardSpeedMultiplier + boostSpeed;
        maxSpeed = maxSpeed + maxSpeedIncrease;
    }
}
