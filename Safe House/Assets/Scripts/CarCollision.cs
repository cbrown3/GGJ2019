﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarCollision : MonoBehaviour
{
    private CarController carController;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if(other.tag == "Building")
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * carController.CurrentSpeed, ForceMode.VelocityChange);
        }
        if (other.tag == "NPC")
        {
            Debug.Log("You hit an NPC");
        }
        if (other.tag == "Tree" || other.tag == "Prop")
        {
            //disable the collider
            other.GetComponent<Collider>().enabled = false;
            //get angle between collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;
            //get the opposite direction and normalize
            dir = -dir.normalized;
            //deactivate gravity
            other.GetComponent<Rigidbody>().useGravity = false;
            //add the force to the tree
            other.GetComponent<Rigidbody>().AddForce(dir * carController.CurrentSpeed * -10.0f);
        }
        if (other.tag == "Car")
        {
            Debug.Log("You hit a car");
        }
    }
}
