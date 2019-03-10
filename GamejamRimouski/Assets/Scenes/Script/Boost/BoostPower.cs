using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BoostPower : MonoBehaviour
{

    public float increaseSpeed = 50;
    public float increaseMaxSpeed = 50;

    public float time = 2.5f;


    public float boostCooldown = 2.5f;
    private bool isUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)
        {
            this.gameObject.SetActive(false);
            boostCooldown -= Time.deltaTime;
        }

        

        if(boostCooldown <= 0)
        {
            isUsed = false;
            this.gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<ControlPlayer>().Boost(increaseSpeed, increaseMaxSpeed, time);

            isUsed = true;
        }
    }
}
